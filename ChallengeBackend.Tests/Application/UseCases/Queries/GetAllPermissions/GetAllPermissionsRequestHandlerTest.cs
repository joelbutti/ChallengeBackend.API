using AutoFixture;
using AutoMapper;
using ChallengeBackend.Application.Interfaces;
using ChallengeBackend.Application.UseCases.Commands.UpdatePermission;
using ChallengeBackend.Application.UseCases.Queries.GetAllPermissions;
using ChallengeBackend.Domain.Entities;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChallengeBackend.Tests.Application.UseCases.Queries.GetAllPermissions
{
    public class GetAllPermissionsRequestHandlerTest
    {
        [Fact]
        public async Task Handle_GetAllPermissions_WithElements()
        {
            //Arrange
            var repository = new Mock<IPermissionRepository>();
            var mapper = new Mock<IMapper>();
            var handler = new GetAllPermissionsRequestHandler(repository.Object, mapper.Object);
            var permissions = new Fixture().Create<IEnumerable<Permission>>();
            var request = new Fixture().Create<GetAllPermissionsRequest>();

            repository.Setup(x => x.GetAllAsync()).ReturnsAsync(permissions);
            //Act
            var response = await handler.Handle(request, CancellationToken.None);

            //Assert
            response.Should().NotBeNull();
        }
    }
}
