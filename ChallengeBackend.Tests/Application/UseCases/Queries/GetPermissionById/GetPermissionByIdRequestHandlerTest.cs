using AutoFixture;
using AutoMapper;
using ChallengeBackend.Application.Interfaces;
using ChallengeBackend.Application.UseCases.Queries.GetAllPermissions;
using ChallengeBackend.Application.UseCases.Queries.GetPermissionById;
using ChallengeBackend.Domain.Entities;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChallengeBackend.Tests.Application.UseCases.Queries.GetPermissionById
{
    public class GetPermissionByIdRequestHandlerTest
    {
        [Fact]
        public async Task Handle_GetPermissionById_WithElements()
        {
            //Arrange
            var repository = new Mock<IPermissionRepository>();
            var mapper = new Mock<IMapper>();
            var handler = new GetPermissionByIdRequestHandler(repository.Object, mapper.Object);
            var permission = new Fixture().Create<Permission>();
            var request = new Fixture().Create<GetPermissionByIdRequest>();

            repository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(permission);
            //Act
            var response = await handler.Handle(request, CancellationToken.None);

            //Assert
            response.Should().NotBeNull();
        }
    }
}
