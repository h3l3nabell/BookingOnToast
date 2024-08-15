using BookingOnToast.Domain.Abstractions;

namespace BookingOnToast.Domain.Bookings.Events;

public record BookingReservedDomainEvent(Guid bookingId) : IDomainEvent;
