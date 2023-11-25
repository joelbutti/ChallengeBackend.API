using ChallengeBackend.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Application.UseCases.Commands.CreatePermission
{
    public record struct CreatePermissionRequest(PermissionDto Permission) :  IRequest<CreatePermissionResponse>;
}
