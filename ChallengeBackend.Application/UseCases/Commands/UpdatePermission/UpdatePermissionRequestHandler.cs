using AutoMapper;
using ChallengeBackend.Application.Interfaces;
using ChallengeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Application.UseCases.Commands.UpdatePermission
{
    public class UpdatePermissionRequestHandler : IRequestHandler<UpdatePermissionRequest, UpdatePermissionResponse>
    {
        private readonly IPermissionRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePermissionRequestHandler(IPermissionRepository permission, IMapper mapper)
        {
            _mapper = mapper;
            _repository = permission;
        }

        public async Task<UpdatePermissionResponse> Handle(UpdatePermissionRequest request, CancellationToken cancellationToken)
        {
            var permissionToUpdate = await _repository.GetByIdAsync(request.Id);

            if (permissionToUpdate is null) return new(null);

            var permission = _mapper.Map<Permission>(request.Permission);

            permission.Id = permissionToUpdate.Id;
            permission.PermissionTypeId = permissionToUpdate.PermissionTypeId;
            permission.PermissionType.Id = permissionToUpdate.PermissionType.Id;

            await _repository.UpdateAsync(permission);

            return new(request.Permission);
        }
    }
}
