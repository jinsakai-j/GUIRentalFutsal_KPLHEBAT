using GuiRentalFutsal.Models;

namespace GuiRentalFutsal.Services;

// 'sealed' dihapus agar mendukung mocking untuk unit testing
public class PaymentService
{
    private readonly JsonDataStore<Booking> _bookingStore;
    private readonly BookingStateMachine _stateMachine;

    public PaymentService(JsonDataStore<Booking> bookingStore, BookingStateMachine stateMachine)
    {
        // Implementasi Design by Contract (Pre-condition)
        _bookingStore = bookingStore ?? throw new ArgumentNullException(nameof(bookingStore));
        _stateMachine = stateMachine ?? throw new ArgumentNullException(nameof(stateMachine));
    }

    // Menambahkan 'virtual' agar method bisa di-override oleh Moq
    public virtual OperationResult<Payment> PayBooking(int bookingId, decimal amountPaid)
    {
        // Defensive Programming: Validasi ID
        if (bookingId <= 0)
        {
            return OperationResult<Payment>.Fail("ID booking tidak valid.");
        }

        // Defensive Programming: Validasi Jumlah
        if (amountPaid <= 0)
        {
            return OperationResult<Payment>.Fail("Jumlah pembayaran harus lebih dari 0.");
        }

        List<Booking> bookings = _bookingStore.Load();
        Booking? booking = bookings.FirstOrDefault(item => item.Id == bookingId);

        if (booking is null)
        {
            return OperationResult<Payment>.Fail("Booking tidak ditemukan.");
        }

        // Integrasi dengan Automata (State Machine)
        if (!_stateMachine.CanMoveTo(booking.Status, BookingStatus.Paid))
        {
            return OperationResult<Payment>.Fail($"Booking dengan status {booking.Status} tidak bisa dibayar.");
        }

        if (amountPaid < booking.TotalPrice)
        {
            return OperationResult<Payment>.Fail("Jumlah pembayaran kurang dari total harga.");
        }

        // Update Status
        booking.Status = BookingStatus.Paid;
        _bookingStore.Save(bookings);

        Payment payment = new()
        {
            BookingId = booking.Id,
            AmountPaid = amountPaid,
            PaidAt = DateTime.Now
        };

        return OperationResult<Payment>.Ok(payment, "Pembayaran berhasil.");
    }
}