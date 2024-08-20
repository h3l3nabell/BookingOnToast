namespace BookingOnToast.Application.Abstactions.Email;

public interface IEmailService
{
    Task SendAsync(Domain.Users.Email recipient, string subject, string body);
}
