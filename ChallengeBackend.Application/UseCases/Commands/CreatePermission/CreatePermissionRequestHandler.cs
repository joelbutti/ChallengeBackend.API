using AutoMapper;
using ChallengeBackend.Application.Interfaces;
using ChallengeBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Application.UseCases.Commands.CreatePermission
{
    public class CreatePermissionRequestHandler : IRequestHandler<CreatePermissionRequest, CreatePermissionResponse>
    {
        private readonly IPermissionRepository _repository;
        private readonly IMapper _mapper;

        public CreatePermissionRequestHandler(IPermissionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreatePermissionResponse> Handle(CreatePermissionRequest request, CancellationToken cancellationToken)
        {
            var permission = _mapper.Map<Permission>(request.Permission);

            await _repository.AddAsync(permission);

            return new(permission.Id);
        }
    }
}
