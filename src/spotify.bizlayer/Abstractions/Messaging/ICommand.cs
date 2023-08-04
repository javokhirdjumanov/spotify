using MediatR;
using spotify.core.Shared;

namespace spotify.bizlayer.Abstractions;
public interface ICommand : IRequest<Result>
{ }

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{ }
