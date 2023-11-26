using AutoFixture;
using AutoMapper;
using ChallengeBackend.Application.Interfaces;
using ChallengeBackend.Application.UseCases.Commands.CreatePermission;
using ChallengeBackend.Domain.Entities;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChallengeBackend.Tests.Application.UseCases.Commands.CreatePermission
{
    public class CreatePermissionRequestHandlerTest
    {
        [Fact]
        public async Task Handle_CreatePermission_OK()
        {
            //Arrange
            var repository = new Mock<IPermissionRepository>();
            var mapper = new Mock<IMapper>();
            var handler = new CreatePermissionRequestHandler(repository.Object, mapper.Object);
            var request = new Fixture().Create<CreatePermissionRequest>();

            repository.Setup(x => x.AddAsync(It.IsAny<Permission>()));
            //Act
            var response = await handler.Handle(request, CancellationToken.None);

            //Assert
            response.Id.Should().NotBe(0);
        }
    }
}
