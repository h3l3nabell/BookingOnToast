using BookingOnToast.Domain.Abstractions;

namespace BookingOnToast.Domain.Bookings.Events;

public record BookingCompletedDomainEvent(Guid bookingId) : IDomainEvent;
