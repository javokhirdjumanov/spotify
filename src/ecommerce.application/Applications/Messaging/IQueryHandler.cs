using ecommerce.domain.Shared;
using MediatR;

namespace ecommerce.application.Applications.Messaging;
public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{

}
