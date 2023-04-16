using ecommerce.domain.Shared;
using MediatR;

namespace ecommerce.application.Applications.Messaging;
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result> 
    where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponse>
    : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}
