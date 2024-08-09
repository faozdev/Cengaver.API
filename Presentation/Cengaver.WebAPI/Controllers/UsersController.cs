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

namespace Cengaver.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

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
