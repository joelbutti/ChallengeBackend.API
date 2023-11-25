using MediatR;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Application.UseCases.Commands.RemovePermission
{
    public record struct RemovePermissionRequest(int Id) : IRequest<RemovePermissionResponse>;
}
