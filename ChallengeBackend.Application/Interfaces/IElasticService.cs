using ChallengeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Application.Interfaces
{
    public interface IElasticService 
    {
        Task<bool> AddRegistry(Permission permission);
    }
}
