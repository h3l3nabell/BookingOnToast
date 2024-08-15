using BookingOnToast.Domain.Abstractions;

namespace BookingOnToast.Domain.Bookings.Events;

public record BookingRejectedDomainEvent(Guid bookingId) : IDomainEvent;
