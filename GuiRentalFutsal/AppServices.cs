using GuiRentalFutsal.Models;
using GuiRentalFutsal.Services;

namespace GuiRentalFutsal
{
    public static class AppServices
    {
        public static JsonDataStore<Field> FieldStore { get; } =
            new JsonDataStore<Field>("Data/fields.json");

        public static JsonDataStore<Booking> BookingStore { get; } =
            new JsonDataStore<Booking>("Data/bookings.json");

        public static FieldService FieldService { get; } =
            new FieldService(FieldStore);

        public static BookingStateMachine BookingStateMachine { get; } =
            new BookingStateMachine();

        public static ScheduleService ScheduleService { get; } =
            new ScheduleService(BookingStore);

        public static BookingService BookingService { get; } =
            new BookingService(
                BookingStore,
                FieldService,
                ScheduleService,
                BookingStateMachine
            );

        public static PaymentService PaymentService { get; } =
            new PaymentService(
                BookingStore,
                BookingStateMachine
            );

        public static ReportService ReportService { get; } =
            new ReportService(BookingService);
    }
}