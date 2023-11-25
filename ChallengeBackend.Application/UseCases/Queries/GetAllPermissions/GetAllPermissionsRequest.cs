using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Application.UseCases.Queries.GetAllPermissions
{
    public record struct GetAllPermissionsRequest() : IRequest<GetAllPermissionsResponse>;
}
