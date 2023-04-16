using ecommerce.domain.Shared;
using MediatR;

namespace ecommerce.application.Applications.Messaging;
public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TRespose> : IRequest<Result<TRespose>>
{
}