using GuiRentalFutsal.Models;

namespace GuiRentalFutsal.Services;

public class ScheduleService
{
    private readonly JsonDataStore<Booking> _bookingStore;

    public ScheduleService(JsonDataStore<Booking> bookingStore)
    {
        _bookingStore = bookingStore ?? throw new ArgumentNullException(nameof(bookingStore));
    }

    public virtual OperationResult<bool> IsAvailable(int fieldId, DateTime startTime, TimeSpan duration)
    {
        if (fieldId <= 0)
        {
            return OperationResult<bool>.Fail("ID lapangan tidak valid.");
        }

        if (duration <= TimeSpan.Zero)
        {
            return OperationResult<bool>.Fail("Durasi booking harus lebih dari 0.");
        }

        TimeSpan start = startTime.TimeOfDay;
        TimeSpan end = start.Add(duration);
        if (start < TimeSpan.FromHours(8) || start > TimeSpan.FromHours(22) || end > TimeSpan.FromHours(23))
        {
            return OperationResult<bool>.Fail("Operasional: 08:00 - 23:00. Jam mulai terakhir 22:00.");
        }

        TimeSlot requestedSlot = new(startTime, duration);
        bool hasConflict = _bookingStore.Load()
            .Where(booking => booking.FieldId == fieldId && booking.Status != BookingStatus.Cancelled)
            .Any(booking => GetBookingSlot(booking).Overlaps(requestedSlot));

        return hasConflict
            ? OperationResult<bool>.Ok(false, "Jadwal bentrok. Pilih jam atau lapangan lain.")
            : OperationResult<bool>.Ok(true, "Jadwal tersedia.");
    }

    public virtual OperationResult<bool> IsAvailable(int fieldId, DateOnly date, TimeOnly startTime, int durationHours)
    {
        if (durationHours <= 0 || durationHours > 15)
        {
            return OperationResult<bool>.Fail("Durasi booking harus 1-15 jam.");
        }

        DateTime slotStart = date.ToDateTime(startTime);
        TimeSpan duration = TimeSpan.FromHours(durationHours);

        return IsAvailable(fieldId, slotStart, duration);
    }

    private static TimeSlot GetBookingSlot(Booking booking)
    {
        DateTime startTime = booking.Date.ToDateTime(booking.StartTime);
        TimeSpan duration = TimeSpan.FromHours(booking.DurationHours);

        return new TimeSlot(startTime, duration);
    }
}
