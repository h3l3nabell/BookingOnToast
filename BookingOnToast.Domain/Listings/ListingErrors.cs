using BookingOnToast.Domain.Abstractions;
namespace BookingOnToast.Domain.Users;

public static class ListingErrors
{
    public static Error NotFound = new("Listing.NotFound", "The listing was not found");
}
