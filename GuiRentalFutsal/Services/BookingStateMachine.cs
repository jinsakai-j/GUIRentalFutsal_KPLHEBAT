using GuiRentalFutsal.Models;
namespace GuiRentalFutsal.Services
{
    public class BookingStateMachine
    {
        private static readonly Dictionary<BookingStatus, BookingStatus[]> ValidTransitions = new()
        {
            [BookingStatus.PendingPayment] = new[] { BookingStatus.Paid, BookingStatus.Cancelled },
            [BookingStatus.Paid] = new[] { BookingStatus.Completed, BookingStatus.Cancelled },
            [BookingStatus.Cancelled] = Array.Empty<BookingStatus>(),
            [BookingStatus.Completed] = Array.Empty<BookingStatus>()
        };
        public virtual bool CanMoveTo(BookingStatus currentStatus, BookingStatus targetStatus)
        {
            return ValidTransitions.TryGetValue(currentStatus, out BookingStatus[]? targets)
                && targets.Contains(targetStatus);
        }
    }
}
