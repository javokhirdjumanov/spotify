using MediatR;
using ecommerce.domain.Shared;

namespace ecommerce.application.Applications.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
