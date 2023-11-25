using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Application.UseCases.Queries.GetPermissionById
{
    public record struct GetPermissionByIdRequest(int Id) : IRequest<GetPermissionByIdResponse>;
}
