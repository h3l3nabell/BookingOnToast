using BookingOnToast.Domain.Abstractions;

namespace BookingOnToast.Domain.Bookings.Events;

public record BookingCancelledDomainEvent(Guid bookingId) : IDomainEvent;
