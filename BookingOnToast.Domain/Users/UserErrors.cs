using BookingOnToast.Domain.Abstractions;
namespace BookingOnToast.Domain.Users;

public static class UserErrors
{
    public static Error NotFound = new("User.NotFound", "The user was not found");
}
