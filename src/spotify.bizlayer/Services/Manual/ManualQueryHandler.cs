using spotify.bizlayer.Abstractions;
using spotify.bizlayer.Services.Users;
using spotify.core.Shared;
using spotify.datalayer.EfClasses;
using spotify.datalayer.Repositories;
using WEBASE.Utility;
using static spotify.core.Errors.DomainError;

namespace spotify.bizlayer.Services.Manual;
public class ManualQueryHandler
{
    public class StatusQueryHandler : 
        IQueryHandler<StatusQuery, GetAllStatusResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        public StatusQueryHandler(IUnitOfWork unitOfWork) 
            => this.unitOfWork = unitOfWork;

        public async Task<Result<GetAllStatusResponse>> Handle(
            StatusQuery request,
            CancellationToken cancellationToken)
        {
            return Result<GetAllStatusResponse>
                .Success(new GetAllStatusResponse(this.unitOfWork
                            .GetContext().Statuses
                            .Select(s => new StatusResponse(s.Id, s.StatusName))
                            .ToList())
                );
        }
    }

    public class StateQueryHandler 
        : IQueryHandler<StateQuery, GetAllStateResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        public StateQueryHandler(IUnitOfWork unitOfWork)
            => this.unitOfWork = unitOfWork;

        public async Task<Result<GetAllStateResponse>> Handle(
            StateQuery request,
            CancellationToken cancellationToken)
        {
            return Result<GetAllStateResponse>
                .Success(new GetAllStateResponse(this.unitOfWork
                            .GetContext().States
                            .Select(s => new StateResponse(s.Id, s.StateName))
                            .ToList())
                );
        }
    }

    public class RoleQueryHandler 
        : IQueryHandler<RoleQuery, GetAllRoleResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        public RoleQueryHandler(IUnitOfWork unitOfWork)
            => this.unitOfWork = unitOfWork;

        public async Task<Result<GetAllRoleResponse>> Handle(
            RoleQuery request,
            CancellationToken cancellationToken)
        {
            return Result<GetAllRoleResponse>
                .Success(new GetAllRoleResponse(this.unitOfWork
                            .GetContext().UserRoles
                            .Select(s => new RoleResponse(s.Id, s.RoleName))
                            .ToList())
                );
        }
    }
}
