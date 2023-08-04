using MediatR;
using spotify.core.Shared;

namespace spotify.bizlayer.Abstractions;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{ }
