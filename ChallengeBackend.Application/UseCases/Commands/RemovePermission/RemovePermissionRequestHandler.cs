using AutoMapper;
using ChallengeBackend.Application.Dtos;
using ChallengeBackend.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Application.UseCases.Commands.RemovePermission
{
    public class RemovePermissionRequestHandler : IRequestHandler<RemovePermissionRequest, RemovePermissionResponse>
    {
        private readonly IPermissionRepository _repository;
        private readonly IMapper _mapper;

        public RemovePermissionRequestHandler(IPermissionRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<RemovePermissionResponse> Handle(RemovePermissionRequest request, CancellationToken cancellationToken)
        {
            var permission = await _repository.GetByIdAsync(request.Id);

            if (permission is null) return new(null);

            await _repository.DeleteAsync(permission);

            var dto = _mapper.Map<PermissionDto>(permission);

            return new(dto);
        }
    }
}
