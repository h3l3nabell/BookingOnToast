using BookingOnToast.Domain.Abstractions;

namespace BookingOnToast.Domain.Users.Events;

public record UserCreatedDomainEvent(Guid userID) : IDomainEvent;

