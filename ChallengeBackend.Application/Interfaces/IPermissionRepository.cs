using ChallengeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Application.Interfaces
{
    public interface IPermissionRepository
    {
        Task AddAsync(Permission entity);
        Task UpdateAsync(Permission entity);
        Task DeleteAsync(Permission entity);
        Task<IEnumerable<Permission>> GetAllAsync();
        Task<Permission?> GetByIdAsync(int id);
    }
}
