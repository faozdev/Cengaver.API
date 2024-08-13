using Cengaver.Dto;
using Cengaver.WebAPI.Model;
using Cengaver.WebAPI.Swagger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Cengaver.BL.Abstractions;
using Cengaver.BL;

namespace Cengaver.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRolesController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        /// <summary>
        /// Gets the list of all user roles.
        /// </summary>
        /// <returns>List of user roles.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<UserRoleDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-user-roles")]
        public async Task<IActionResult> GetUserRoles()
        {
            var serviceResult = await _userRoleService.GetUserRolesAsync().ConfigureAwait(false);
            return Ok(serviceResult);
        }

        /// <summary>
        /// Gets a specific user role by user ID and role ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="roleId">The ID of the role.</param>
        /// <returns>Details of the specified user role.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<UserRoleDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-user-role/{userId}/{roleId}")]
        public async Task<IActionResult> GetUserRoleById(string userId, int roleId)
        {
            var serviceResult = await _userRoleService.GetUserRoleByIdAsync(userId, roleId).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Adds a new user role.
        /// </summary>
        /// <param name="userRoleCreateDto">The user role details to add.</param>
        /// <returns>Result of the add operation.</returns>
        [SwaggerResponse(201, type: typeof(SuccessResponse<UserRoleDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPost("add-user-role")]
        public async Task<IActionResult> AddUserRole([FromBody] UserRoleCreateDto userRoleCreateDto)
        {
            var serviceResult = await _userRoleService.AddUserRoleAsync(userRoleCreateDto).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetUserRoleById), new { userId = serviceResult.UserId, roleId = serviceResult.RoleId }, serviceResult);
        }

        /// <summary>
        /// Updates an existing user role.
        /// </summary>
        /// <param name="userId">The ID of the user to update.</param>
        /// <param name="roleId">The ID of the role to update.</param>
        /// <param name="userRoleUpdateDto">The updated user role details.</param>
        /// <returns>Result of the update operation.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<UserRoleDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPut("update-user-role/{userId}/{roleId}")]
        public async Task<IActionResult> UpdateUserRole(string userId, int roleId, [FromBody] UserRoleUpdateDto userRoleUpdateDto)
        {
            var serviceResult = await _userRoleService.UpdateUserRoleAsync(userId, roleId, userRoleUpdateDto).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Deletes a specific user role by user ID and role ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="roleId">The ID of the role to delete.</param>
        /// <returns>Result of the delete operation.</returns>
        [SwaggerResponse(204, description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpDelete("delete-user-role/{userId}/{roleId}")]
        public async Task<IActionResult> DeleteUserRole(string userId, int roleId)
        {
            var success = await _userRoleService.DeleteUserRoleAsync(userId, roleId).ConfigureAwait(false);
            if (!success)
                return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Gets the list of user roles for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>List of user roles associated with the user.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<UserRoleDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-user-roles-by-user/{userId}")]
        public async Task<IActionResult> GetUserRolesByUser(string userId)
        {
            var serviceResult = await _userRoleService.GetUserRolesByUserIdAsync(userId).ConfigureAwait(false);
            if (serviceResult == null || !serviceResult.Any())
                return NotFound();
            return Ok(serviceResult);
        }
    }

    
}
