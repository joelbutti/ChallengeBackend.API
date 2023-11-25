using ChallengeBackend.Application.Interfaces;
using ChallengeBackend.Domain.Constants;
using ChallengeBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Infrastructure.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ChallengeBackendContext _context;
        private readonly IElasticService _elasticService;
        private readonly IKafkaService _kafkaService;

        public PermissionRepository(ChallengeBackendContext context, IElasticService elasticService, IKafkaService kafkaService)
        {
            _context = context;
            _elasticService = elasticService;
            _kafkaService = kafkaService;
        }

        public async Task AddAsync(Permission entity)
        {
            _context.Permissions.Add(entity);

            await _context.SaveChangesAsync();

            await _elasticService.AddRegistry(entity);

            await _kafkaService.ProduceMessageAsync(new(Guid.NewGuid(), OperationType.REQUEST));
        }

        public async Task DeleteAsync(Permission entity)
        {
            _context.Permissions.Remove(entity);

            await _context.SaveChangesAsync();

            await _elasticService.AddRegistry(entity);

            await _kafkaService.ProduceMessageAsync(new(Guid.NewGuid(), OperationType.REQUEST));

        }

        public async Task UpdateAsync(Permission entity)
        {
            _context.Permissions.Update(entity);

            await _context.SaveChangesAsync();

            await _elasticService.AddRegistry(entity);

            await _kafkaService.ProduceMessageAsync(new(Guid.NewGuid(), OperationType.MODIFY));

        }
        public async Task<IEnumerable<Permission>> GetAllAsync() => await _context.Permissions.AsNoTracking().Include(typeof(PermissionType).Name).ToListAsync();

        public async Task<Permission?> GetByIdAsync(int id)
        {
            var permission = await _context.Permissions.AsNoTracking().Include(typeof(PermissionType).Name).FirstOrDefaultAsync(x => x.Id == id);

            if (permission is not null) await _elasticService.AddRegistry(permission);

            await _kafkaService.ProduceMessageAsync(new(Guid.NewGuid(), OperationType.GET));

            return permission;
        }
    }
}
