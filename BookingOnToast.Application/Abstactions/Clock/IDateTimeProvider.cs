namespace BookingOnToast.Application.Abstactions.Clock;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
