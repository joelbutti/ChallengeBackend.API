using ChallengeBackend.Application.Interfaces;
using ChallengeBackend.Infrastructure.Repositories;
using ChallengeBackend.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Infrastructure.Boopstrap
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChallengeBackendContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("ChallengeBackendConnection"),
                   b => b.MigrationsAssembly(typeof(ChallengeBackendContext).Assembly.FullName)));

            services.AddSingleton<IElasticClient>(provider =>
            {
                var settings = new ConnectionSettings(new Uri(configuration["Elasticsearch:ServerUrl"] ?? string.Empty))
                    .DefaultIndex(configuration["Elasticsearch:IndexName"]);

                return new ElasticClient(settings);
            });

            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IElasticService, ElasticService>();
            services.AddScoped<IKafkaService, KafkaService>();
        }
    }
}
