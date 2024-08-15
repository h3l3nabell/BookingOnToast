using BookingOnToast.Domain.Common;

namespace BookingOnToast.Domain.Bookings;

public record PricingDetails
(
    Money PriceForPeriod,
    Money CleaningFee,
    Money AmenitiesUpCharge,
    Money TotalPrice
    );
