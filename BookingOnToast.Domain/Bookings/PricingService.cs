using BookingOnToast.Domain.Common;
using BookingOnToast.Domain.Listings;

namespace BookingOnToast.Domain.Bookings;

internal class PricingService
{
    public PricingDetails CalculatePrice(Listing listing, DateRange period)
    {
        var currency = listing.Price.Currency;
        var priceForPeriod = new Money(listing.Price.Amount * period.LengthInDays, listing.Price.Currency);

        decimal percentageUpcharge = 0;
        foreach (var amenity in listing.Amenities)
        {
            percentageUpcharge +=
                amenity switch
                {
                    Amenity.Garden => 0.05m,
                    Amenity.Wifi => 0.01m,
                    Amenity.Parking => 0.01m,
                    _ => 0m
                };
        }

        Money amenitiesUpcharge = Money.Zero();
        if (percentageUpcharge > 0)
        {
            amenitiesUpcharge = new Money(priceForPeriod.Amount * percentageUpcharge, currency);
        }

        var totalPrice = Money.Zero();
        totalPrice += priceForPeriod;
        totalPrice += amenitiesUpcharge;
        if (!listing.CleaningFee.IsZero())
        {
            totalPrice += listing.CleaningFee;
        }

        return new PricingDetails(priceForPeriod, listing.CleaningFee, amenitiesUpcharge, totalPrice);
    }
}
