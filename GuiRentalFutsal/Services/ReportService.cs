using GuiRentalFutsal.Models;

namespace GuiRentalFutsal.Services;

// 1. HAPUS 'sealed' agar Moq bisa membuat proxy/subclass untuk testing
public class ReportService
{
    private readonly BookingService _bookingService;

    public ReportService(BookingService bookingService)
    {
        // Tetap pertahankan ini (Poin penilaian Design by Contract)
        _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
    }

    // 2. TAMBAHKAN 'virtual' agar method ini bisa di-override/diakses oleh alat testing
    public virtual void PrintBookingReport()
    {
        List<Booking> bookings = _bookingService.GetAllBookings();
        if (bookings.Count == 0)
        {
            Console.WriteLine("Belum ada data booking.");
            return;
        }

        Console.WriteLine("=== LAPORAN BOOKING ===");
        foreach (Booking booking in bookings)
        {
            Console.WriteLine(booking);
        }

        decimal paidIncome = bookings
            .Where(booking => booking.Status == BookingStatus.Paid || booking.Status == BookingStatus.Completed)
            .Sum(booking => booking.TotalPrice);

        Console.WriteLine($"Total pemasukan terbayar: Rp{paidIncome:N0}");
    }
}