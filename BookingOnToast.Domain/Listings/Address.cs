namespace BookingOnToast.Domain.Listings;

public record Address
(
     string Country,
     string PostCode,
     string Street,
     string City,
     string County,
     string CountryCode 
);
