using BookingOnToast.Domain.Abstractions;
using BookingOnToast.Domain.Bookings.Events;
using BookingOnToast.Domain.Common;
using BookingOnToast.Domain.Listings;

namespace BookingOnToast.Domain.Bookings;

public sealed class Booking : Entity
{
    private Booking(Guid id,
        Guid listingId,
        Guid userID,
        DateRange duration,
        Money priceForPeriod,
        Money cleaningFee,
        Money amenitiesUpCharge,
        Money totalPrice,
        BookingStatus status,
        DateTime createdOnUTC
        ) 
        : base(id)
    {        
        ListingID = listingId;
        UserID = userID;
        Duration = duration;
        PriceForPeriod = priceForPeriod;
        CleaningFee = cleaningFee;
        AmenitiesUpCharge = amenitiesUpCharge;
        TotalPrice = totalPrice;
        Status = status;
        CreatedOnUTC = createdOnUTC;
    }
    public Guid ListingID { get; private set; }
    public Guid UserID { get; private set; }

    public DateRange Duration { get; private set; }
    public Money PriceForPeriod { get; private set; }
    public Money CleaningFee { get; private set; }
    public Money AmenitiesUpCharge { get; private set; }
    public Money TotalPrice { get; private set; }
    public BookingStatus Status { get; private set; }
    public DateTime CreatedOnUTC { get; private set; }
    public DateTime ConfirmedOnUTC { get; private set; }
    public DateTime RejectedOnUtc { get; private set; }
    public DateTime CancelledOnUtc { get; private set; }

    public static Booking Reserve(
        Listing listing,
        Guid userID,
        DateRange duration,
        DateTime utcNow,
        PricingService pricingService)
    {
        var pricingDetails = pricingService.CalculatePrice(listing, duration);
        var booking = new Booking(
            Guid.NewGuid(),
            listing.Id,
            userID,
            duration,
            pricingDetails.PriceForPeriod,
            pricingDetails.CleaningFee,
            pricingDetails.AmenitiesUpCharge,
            pricingDetails.TotalPrice,
            BookingStatus.Reserved,
            utcNow);
        booking.RaiseDomainEvent(new BookingReservedDomainEvent(booking.Id));
        listing.LastBookedOnUTC = utcNow;
        return booking;
    }
}
