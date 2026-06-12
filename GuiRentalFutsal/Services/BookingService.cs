using GuiRentalFutsal.Models;
namespace GuiRentalFutsal.Services
{
    public class BookingService
    {
        private readonly JsonDataStore<Booking> _bookingStore;
        private readonly FieldService _fieldService;
        private readonly ScheduleService _scheduleService;
        private readonly BookingStateMachine _stateMachine;

        public BookingService(JsonDataStore<Booking> bookingStore, FieldService fieldService, ScheduleService scheduleService, BookingStateMachine stateMachine)
        {
            _bookingStore = bookingStore ?? throw new ArgumentNullException(nameof(bookingStore));
            _fieldService = fieldService ?? throw new ArgumentNullException(nameof(fieldService));
            _scheduleService = scheduleService ?? throw new ArgumentNullException(nameof(scheduleService));
            _stateMachine = stateMachine ?? throw new ArgumentNullException(nameof(stateMachine));
        }

        public virtual List<Booking> GetAllBookings()
        {
            return _bookingStore.Load()
                .OrderBy(booking => booking.Date)
                .ThenBy(booking => booking.StartTime)   
                .ToList();
        }

        public virtual List<Booking> GetBookingsByDate(DateOnly date)
        {
            return _bookingStore.Load()
                .Where(booking => booking.Date == date && booking.Status != BookingStatus.Cancelled)
                .OrderBy(booking => booking.FieldId)
                .ThenBy(booking => booking.StartTime)
                .ToList();
        }

        public virtual OperationResult<Booking> CreateBooking(int fieldId, string customerName, string customerPhone, DateOnly date, TimeOnly startTime, int durationHours)
        {
            Field? field = _fieldService.GetById(fieldId);
            if (field is null) return OperationResult<Booking>.Fail("Lapangan tidak ditemukan atau tidak aktif.");
            if (string.IsNullOrWhiteSpace(customerName)) return OperationResult<Booking>.Fail("Nama tidak boleh kosong.");
            if (string.IsNullOrWhiteSpace(customerPhone)) return OperationResult<Booking>.Fail("Nomor HP tidak boleh kosong.");
            if (durationHours <= 0 || durationHours > 15)
            {
                return OperationResult<Booking>.Fail("Durasi harus 1-15 jam.");
            }
            if (startTime.Minute != 0) return OperationResult<Booking>.Fail("Jam mulai harus tepat (contoh 18:00).");

            TimeSpan start = startTime.ToTimeSpan();
            TimeSpan end = start.Add(TimeSpan.FromHours(durationHours));
            if (start < TimeSpan.FromHours(8) || end > TimeSpan.FromHours(23)) return OperationResult<Booking>.Fail("Operasional: 08:00 - 23:00.");

            var availabilityResult = _scheduleService.IsAvailable(fieldId, date, startTime, durationHours);
            if (!availabilityResult.Success || !availabilityResult.Data) return OperationResult<Booking>.Fail(availabilityResult.Message);

            List<Booking> bookings = _bookingStore.Load();
            int nextId = bookings.Count == 0 ? 1 : bookings.Max(b => b.Id) + 1;

            Booking newBooking = new()
            {
                Id = nextId,
                FieldId = fieldId,
                CustomerName = customerName.Trim(),
                CustomerPhone = customerPhone.Trim(),
                Date = date,
                StartTime = startTime,
                DurationHours = durationHours,
                TotalPrice = field.PricePerHour * durationHours,
                Status = BookingStatus.PendingPayment
            };

            bookings.Add(newBooking);
            _bookingStore.Save(bookings);
            return OperationResult<Booking>.Ok(newBooking, "Booking berhasil dibuat.");
        }

        public virtual OperationResult<Booking> PayBooking(int bookingId, decimal amountPaid)
        {
            if (bookingId <= 0) return OperationResult<Booking>.Fail("ID tidak valid.");
            List<Booking> bookings = _bookingStore.Load();
            Booking? booking = bookings.FirstOrDefault(b => b.Id == bookingId);

            if (booking is null) return OperationResult<Booking>.Fail("Booking tidak ditemukan.");
            if (!_stateMachine.CanMoveTo(booking.Status, BookingStatus.Paid)) return OperationResult<Booking>.Fail($"Status {booking.Status} tidak bisa dibayar.");
            if (amountPaid < booking.TotalPrice) return OperationResult<Booking>.Fail("Uang kurang.");

            booking.Status = BookingStatus.Paid;
            _bookingStore.Save(bookings);
            return OperationResult<Booking>.Ok(booking, "Pembayaran berhasil.");
        }

        public virtual OperationResult<Booking> CancelBooking(int bookingId)
        {
            if (bookingId <= 0) return OperationResult<Booking>.Fail("ID tidak valid.");
            List<Booking> bookings = _bookingStore.Load();
            Booking? booking = bookings.FirstOrDefault(b => b.Id == bookingId);

            if (booking is null) return OperationResult<Booking>.Fail("Booking tidak ditemukan.");
            if (!_stateMachine.CanMoveTo(booking.Status, BookingStatus.Cancelled)) return OperationResult<Booking>.Fail("Tidak bisa dibatalkan.");

            booking.Status = BookingStatus.Cancelled;
            _bookingStore.Save(bookings);
            return OperationResult<Booking>.Ok(booking, "Booking berhasil dibatalkan.");
        }

        public static bool IsTimeOverlap(TimeOnly startA, TimeOnly endA, TimeOnly startB, TimeOnly endB)
        {
            return startA < endB && startB < endA;
        }
    }
}
