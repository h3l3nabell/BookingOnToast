using BookingOnToast.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingOnToast.Domain.Listings
{
    public sealed class Listing : Entity
    {
        public Listing(int id) : base(id) { }

        public string Name { get; private set; }
        public string Description { get; private set; }
       
        public Address Address { get; private set; }

        public decimal PriceAmount {  get; private set; }
        public string PriceCurrency {  get; private set; }

        public DateTime? LastBookedOnUTC {  get; private set; }

        public List<Amenity> Amenities { get; private set; } = new();
    }
}
