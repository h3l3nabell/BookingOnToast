using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
