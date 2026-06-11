namespace GuiRentalFutsal.Models;

public sealed class Payment
{
    public int BookingId { get; set; }
    public decimal AmountPaid { get; set; }
    public DateTime PaidAt { get; set; } = DateTime.Now;
}
