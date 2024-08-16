using BookingOnToast.Domain.Abstractions;
using MediatR;

namespace BookingOnToast.Application.Abstactions.Messaging;

//Enforce that our commands must return a Result, and also possibility of another value 
public interface ICommand : IRequest<Result> , IBaseCommand
{
}
public interface ICommand<TResponse> : IRequest<Result<TResponse>> , IBaseCommand
{
}

public interface IBaseCommand
{ 
}