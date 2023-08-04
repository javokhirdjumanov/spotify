using MediatR;
using spotify.core.Shared;

namespace spotify.bizlayer.Abstractions;
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{ }

public interface ICommandHandler<TCommand, TRespose>
    : IRequestHandler<TCommand, Result<TRespose>>
    where TCommand : ICommand<TRespose>
{ }
