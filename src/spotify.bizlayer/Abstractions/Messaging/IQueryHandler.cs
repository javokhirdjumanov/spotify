using MediatR;
using spotify.core.Shared;

namespace spotify.bizlayer.Abstractions;
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}

