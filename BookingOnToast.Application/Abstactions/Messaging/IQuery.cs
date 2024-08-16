using BookingOnToast.Domain.Abstractions;
using MediatR;

namespace BookingOnToast.Application.Abstactions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
