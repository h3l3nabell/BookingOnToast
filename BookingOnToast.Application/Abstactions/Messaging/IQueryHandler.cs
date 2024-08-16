using BookingOnToast.Domain.Abstractions;
using MediatR;

namespace BookingOnToast.Application.Abstactions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> 
    where TQuery : IQuery<TResponse>
{

}
