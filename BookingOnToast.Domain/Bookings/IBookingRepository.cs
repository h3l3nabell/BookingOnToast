using BookingOnToast.Domain.Listings;

namespace BookingOnToast.Domain.Bookings;

public interface IBookingRepository
{
    void Add(Booking booking);
    Task<Booking> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> IsOverlappingAsync(Listing listing, DateRange duration, CancellationToken cancellationToken);
}
