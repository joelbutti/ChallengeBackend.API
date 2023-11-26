using AutoFixture;
using AutoMapper;
using ChallengeBackend.Application.Interfaces;
using ChallengeBackend.Application.UseCases.Commands.CreatePermission;
using ChallengeBackend.Application.UseCases.Commands.RemovePermission;
using ChallengeBackend.Domain.Entities;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChallengeBackend.Tests.Application.UseCases.Commands.RemovePermission
{
    public class RemovePermissionRequestHandlerTest
    {
        [Fact]
        public async Task Handle_RemovePermission_OK()
        {
            //Arrange
            var repository = new Mock<IPermissionRepository>();
            var mapper = new Mock<IMapper>();
            var handler = new RemovePermissionRequestHandler(repository.Object, mapper.Object);
            var permission = new Fixture().Create<Permission>();
            var request = new Fixture().Create<RemovePermissionRequest>();

            repository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(permission);
            repository.Setup(x => x.DeleteAsync(It.IsAny<Permission>()));
            //Act
            var response = await handler.Handle(request, CancellationToken.None);

            //Assert
            response.Should().NotBeNull();
        }
    }
}
