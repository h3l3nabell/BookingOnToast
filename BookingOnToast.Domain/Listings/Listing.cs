﻿using BookingOnToast.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingOnToast.Domain.Listings;

public sealed class Listing : Entity
{
    public Listing(Guid id
        , Name name
        , Description description
        , Address address
        , Money price
        , Money cleaningFee
        , List<Amenity> amenities)
        : base(id)
    {
        Name = name;
        Description = description;
        Address = address;
        Price = price;
        CleaningFee = cleaningFee;
        Amenities = amenities;
    }

    public Name Name { get; private set; }
    public Description Description { get; private set; }

    public Address Address { get; private set; }

    public Money Price { get; private set; }

    public Money CleaningFee { get; private set; }

    public DateTime? LastBookedOnUTC { get; private set; }

    public List<Amenity> Amenities { get; private set; } = new();
}

