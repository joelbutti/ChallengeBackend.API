using ChallengeBackend.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Application.UseCases.Queries.GetAllPermissions
{
    public record struct GetAllPermissionsResponse(List<PermissionDto> Permissions);
}
