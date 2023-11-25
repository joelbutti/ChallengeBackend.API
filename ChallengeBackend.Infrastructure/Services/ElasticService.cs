using ChallengeBackend.Application.Interfaces;
using ChallengeBackend.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Infrastructure.Services
{
    public class ElasticService : IElasticService
    {
        private readonly IElasticClient _client;

        public ElasticService(IElasticClient client)
        {
            _client = client;
        }

        public async Task<bool> AddRegistry(Permission permission)
        {
            var indexResponse = await _client.IndexDocumentAsync(permission);

            return indexResponse.IsValid;
        }
    }
}
