using Cengaver.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cengaver.BL;
using Cengaver.BL.Abstractions;
using Cengaver.Dto;
using Cengaver.WebAPI.Model;
using Cengaver.WebAPI.Swagger;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace Cengaver.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        [Authorize]
        [HttpGet("current-user")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token == null)
            {
                return Unauthorized();
            }

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            var userId = jsonToken?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Unauthorized();
            }

            var currentUser = await _userService.GetUserByIdAsync(userId);
            if (currentUser == null)
            {
                return NotFound();
            }

            return Ok(currentUser);
        }

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-users")]
        public async Task<IActionResult> GetUsers()
        {
            var serviceResult = await _userService.GetUsersAsync();
            var userList = serviceResult.ToList(); 
            return Ok(new SuccessResponse<List<UserDto>> { Data = userList });
        }


        [HttpGet("get-user/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var serviceResult = await _userService.GetUserByIdAsync(id);
            if (serviceResult == null)
                return NotFound();
            return Ok(new SuccessResponse<UserDto> { Data = serviceResult });
        }

        [HttpGet("get-username/{id}")]
        public async Task<IActionResult> GetUserNameById(string id)
        {
            var userName = await _userService.GetUserNameByIdAsync(id);
            if (userName == null)
                return NotFound();
            return Ok(new SuccessResponse<string> { Data = userName });
        }


        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
        {
            var serviceResult = await _userService.AddUserAsync(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = serviceResult.Id }, serviceResult);
        }

        [HttpPut("update-user/{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserDto userDto)
        {
            var serviceResult = await _userService.UpdateUserAsync(id, userDto);
            if (serviceResult == null)
                return NotFound();
            return Ok(new SuccessResponse<UserDto> { Data = serviceResult });
        }

        [HttpDelete("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var success = await _userService.DeleteUserAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }



}
