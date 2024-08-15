namespace BookingOnToast.Domain.Listings;

public interface IListingRepository
{
    Task<Listing> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
