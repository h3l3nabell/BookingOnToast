using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingOnToast.Domain.Abstractions;

public abstract class Entity
{
    protected Entity(int id)
    {
        Id = id;
    }
    public int Id { get; init; }
}

