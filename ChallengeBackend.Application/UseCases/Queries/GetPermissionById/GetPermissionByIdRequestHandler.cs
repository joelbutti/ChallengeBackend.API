using AutoMapper;
using ChallengeBackend.Application.Dtos;
using ChallengeBackend.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Application.UseCases.Queries.GetPermissionById
{
    public class GetPermissionByIdRequestHandler : IRequestHandler<GetPermissionByIdRequest, GetPermissionByIdResponse>
    {
        private readonly IPermissionRepository _repository;
        private readonly IMapper _mapper;

        public GetPermissionByIdRequestHandler(IPermissionRepository permission, IMapper mapper)
        {
            _mapper = mapper;
            _repository = permission;
        }
        public async Task<GetPermissionByIdResponse> Handle(GetPermissionByIdRequest request, CancellationToken cancellationToken)
        {
            var permission = await _repository.GetByIdAsync(request.Id);

            var permissionDto = _mapper.Map<PermissionDto>(permission);

            return new(permissionDto);
        }
    }
}
