using AutoMapper;
using ChallengeBackend.Application.Dtos;
using ChallengeBackend.Application.Interfaces;
using MediatR;

namespace ChallengeBackend.Application.UseCases.Queries.GetAllPermissions
{
    public class GetAllPermissionsRequestHandler : IRequestHandler<GetAllPermissionsRequest, GetAllPermissionsResponse>
    {
        private readonly IPermissionRepository _repository;
        private readonly IMapper _mapper;

        public GetAllPermissionsRequestHandler(IPermissionRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GetAllPermissionsResponse> Handle(GetAllPermissionsRequest request, CancellationToken cancellationToken)
        {
            var permissions = await _repository.GetAllAsync();

            var permissionsDto = _mapper.Map<IEnumerable<PermissionDto>>(permissions);

            return new GetAllPermissionsResponse(permissionsDto.ToList());
        }
    }
}
