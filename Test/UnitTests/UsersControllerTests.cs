using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Cengaver.Dto;
using Cengaver.BL.Abstractions;
using Cengaver.WebAPI.Controllers;
using Cengaver.WebAPI.Model;

namespace UnitTests
{
    public class UsersControllerTests
    {
        private readonly UsersController _controller;
        private readonly Mock<IUserService> _userServiceMock;

        public UsersControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _controller = new UsersController(_userServiceMock.Object);
        }

        [Fact]
        public async Task GetUsers_ReturnsOkResult_WithListOfUsers()
        {
            // Arrange
            var users = new List<UserDto>
            {
                new UserDto { Id = 1, UserName = "User1", SicilNo = "12345", UserRegistrationDate = DateTime.Now },
                new UserDto { Id = 2, UserName = "User2", SicilNo = "67890", UserRegistrationDate = DateTime.Now }
            };
            _userServiceMock.Setup(service => service.GetUsersAsync()).ReturnsAsync(users);

            // Act
            var result = await _controller.GetUsers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SuccessResponse<List<UserDto>>>(okResult.Value);
            Assert.Equal(users, returnValue.Data);
        }

        [Fact]
        public async Task GetUserById_ReturnsOkResult_WithUser()
        {
            // Arrange
            var user = new UserDto { Id = 1, UserName = "User1", SicilNo = "12345", UserRegistrationDate = DateTime.Now };
            _userServiceMock.Setup(service => service.GetUserByIdAsync(1)).ReturnsAsync(user);

            // Act
            var result = await _controller.GetUserById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SuccessResponse<UserDto>>(okResult.Value);
            Assert.Equal(user, returnValue.Data);
        }

        [Fact]
        public async Task GetUserById_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            _userServiceMock.Setup(service => service.GetUserByIdAsync(1)).ReturnsAsync((UserDto)null);

            // Act
            var result = await _controller.GetUserById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task AddUser_ReturnsCreatedAtActionResult_WithUser()
        {
            // Arrange
            var userDto = new UserDto { Id = 1, UserName = "User1", SicilNo = "12345", UserRegistrationDate = DateTime.Now };
            _userServiceMock.Setup(service => service.AddUserAsync(userDto)).ReturnsAsync(userDto);

            // Act
            var result = await _controller.AddUser(userDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnValue = Assert.IsType<SuccessResponse<UserDto>>(createdAtActionResult.Value);
            Assert.Equal(userDto, returnValue.Data);
        }

        [Fact]
        public async Task UpdateUser_ReturnsOkResult_WithUpdatedUser()
        {
            // Arrange
            var userDto = new UserDto { Id = 1, UserName = "UpdatedUser", SicilNo = "12345", UserRegistrationDate = DateTime.Now };
            _userServiceMock.Setup(service => service.UpdateUserAsync(1, userDto)).ReturnsAsync(userDto);

            // Act
            var result = await _controller.UpdateUser(1, userDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SuccessResponse<UserDto>>(okResult.Value);
            Assert.Equal(userDto, returnValue.Data);
        }

        [Fact]
        public async Task UpdateUser_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            var userDto = new UserDto { Id = 1, UserName = "UpdatedUser", SicilNo = "12345", UserRegistrationDate = DateTime.Now };
            _userServiceMock.Setup(service => service.UpdateUserAsync(1, userDto)).ReturnsAsync((UserDto)null);

            // Act
            var result = await _controller.UpdateUser(1, userDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteUser_ReturnsNoContent_WhenUserIsDeleted()
        {
            // Arrange
            _userServiceMock.Setup(service => service.DeleteUserAsync(1)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteUser(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteUser_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            _userServiceMock.Setup(service => service.DeleteUserAsync(1)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteUser(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
