using MediatR;

namespace ecommerce.application.Applications.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
