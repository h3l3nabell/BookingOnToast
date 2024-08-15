using BookingOnToast.Domain.Abstractions;

namespace BookingOnToast.Domain.Bookings.Events;

public record BookingConfirmedDomainEvent(Guid bookingId) : IDomainEvent;
