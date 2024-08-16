using BookingOnToast.Application.Abstactions.Messaging;

namespace BookingOnToast.Application.Bookings.ReserveBooking;

public record ReserveBookingCommand (
    Guid ApartmentId,
    Guid UserID, 
    DateOnly StartDate,
    DateOnly EndDate
    ) : ICommand<Guid>;

