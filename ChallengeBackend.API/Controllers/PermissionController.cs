using ChallengeBackend.Application.Dtos;
using ChallengeBackend.Application.UseCases.Commands.CreatePermission;
using ChallengeBackend.Application.UseCases.Commands.RemovePermission;
using ChallengeBackend.Application.UseCases.Commands.UpdatePermission;
using ChallengeBackend.Application.UseCases.Queries.GetAllPermissions;
using ChallengeBackend.Application.UseCases.Queries.GetPermissionById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeBackend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermissionById(int id) => Ok(await _mediator.Send(new GetPermissionByIdRequest(id)));

        [HttpGet]
        public async Task<IActionResult> GetAllPermissions() => Ok(await _mediator.Send(new GetAllPermissionsRequest()));

        [HttpPost]
        public async Task<IActionResult> CreatePermission(PermissionDto dto) => Ok(await _mediator.Send(new CreatePermissionRequest(dto)));

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePermission(int id) => Ok(await _mediator.Send(new RemovePermissionRequest(id)));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePermission(int id, PermissionDto dto) => Ok(await _mediator.Send(new UpdatePermissionRequest(id, dto)));
    }
}
