using BookingOnToast.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingOnToast.Domain.User.Events;

public record UserCreatedDomainEvent(Guid userID) : IDomainEvent;

