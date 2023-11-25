using AutoMapper;
using ChallengeBackend.Application.Dtos;
using ChallengeBackend.Application.UseCases.Commands.CreatePermission;
using ChallengeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Application.Mapper
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<Permission, PermissionDto>().ReverseMap();
            CreateMap<PermissionType, PermissionTypeDto>().ReverseMap();
        }
    }
}
