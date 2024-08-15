namespace BookingOnToast.Domain.User;

public interface IUserRepository
{
    Task<User?> GetByIDAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(User user);
}
