using BookingOnToast.Domain.Bookings;
using Microsoft.Extensions.DependencyInjection;

namespace BookingOnToast.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Configure MediatR
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        services.AddTransient<PricingService>();
        return services;
    }

}
