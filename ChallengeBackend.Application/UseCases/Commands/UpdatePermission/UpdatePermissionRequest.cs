using ChallengeBackend.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Application.UseCases.Commands.UpdatePermission
{
    public record struct UpdatePermissionRequest(int Id, PermissionDto Permission) : IRequest<UpdatePermissionResponse>;
}
