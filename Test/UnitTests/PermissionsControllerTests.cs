using AutoMapper;
using Cengaver.Domain;
using Cengaver.Dto;
using Cengaver.BL.Abstractions;
using Cengaver.WebAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Cengaver.Services.Mappings;

namespace UnitTests
{
    public class PermissionsControllerTests
    {
        private readonly Mock<IPermissionService> _permissionServiceMock;
        private readonly PermissionsController _controller;

        public PermissionsControllerTests()
        {
            _permissionServiceMock = new Mock<IPermissionService>();
            _controller = new PermissionsController(_permissionServiceMock.Object);
        }

        [Fact]
        public async Task AddPermission_ShouldReturnCreatedResult()
        {
            // Arrange
            var permissionDto = new PermissionDto { RoleId = 1, UserPermission = "Read" };
            var permission = new Permission { RoleId = 1, UserPermission = "Read" };

            _permissionServiceMock.Setup(x => x.AddAsync(It.IsAny<PermissionDto>()))
                .ReturnsAsync(permissionDto);

            // Act
            var result = await _controller.AddPermission(permissionDto);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnedValue = Assert.IsType<PermissionDto>(actionResult.Value);
            Assert.Equal(permissionDto.RoleId, returnedValue.RoleId);
            Assert.Equal(permissionDto.UserPermission, returnedValue.UserPermission);
        }

        [Fact]
        public async Task UpdatePermission_ShouldReturnOkResult()
        {
            // Arrange
            var permissionDto = new PermissionDto { RoleId = 1, UserPermission = "Read" };
            var updatedPermissionDto = new PermissionDto { RoleId = 1, UserPermission = "Write" };

            _permissionServiceMock.Setup(x => x.UpdateAsync(It.IsAny<PermissionDto>()))
                .ReturnsAsync(updatedPermissionDto);

            // Act
            var result = await _controller.UpdatePermission(permissionDto.RoleId, permissionDto.UserPermission, permissionDto);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnedValue = Assert.IsType<PermissionDto>(actionResult.Value);
            Assert.Equal(updatedPermissionDto.RoleId, returnedValue.RoleId);
            Assert.Equal(updatedPermissionDto.UserPermission, returnedValue.UserPermission);
        }
    }


}
