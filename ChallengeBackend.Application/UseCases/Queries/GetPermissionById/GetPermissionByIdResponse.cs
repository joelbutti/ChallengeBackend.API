

using ChallengeBackend.Application.Dtos;

namespace ChallengeBackend.Application.UseCases.Queries.GetPermissionById
{
    public record struct GetPermissionByIdResponse(PermissionDto Permission);
}
