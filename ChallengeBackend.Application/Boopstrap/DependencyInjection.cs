﻿
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ChallengeBackend.Application.Boopstrap
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
