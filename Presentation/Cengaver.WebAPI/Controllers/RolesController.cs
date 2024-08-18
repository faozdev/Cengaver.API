using Cengaver.Dto;
using Cengaver.WebAPI.Model;
using Cengaver.WebAPI.Swagger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cengaver.BL;
using Cengaver.BL.Abstractions;
using Swashbuckle.AspNetCore.Annotations;

namespace Cengaver.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Gets the list of all roles.
        /// </summary>
        /// <returns>List of roles.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<RoleDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-roles")]
        public async Task<IActionResult> GetRoles()
        {
            var serviceResult = await _roleService.GetRolesAsync().ConfigureAwait(false);
            return Ok(serviceResult);
        }

        /// <summary>
        /// Gets a specific role by ID.
        /// </summary>
        /// <param name="id">The ID of the role.</param>
        /// <returns>Details of the specified role.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<RoleDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-role/{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var serviceResult = await _roleService.GetRoleByIdAsync(id).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Adds a new role.
        /// </summary>
        /// <param name="roleCreateDto">The role details to add.</param>
        /// <returns>Result of the add operation.</returns>
        [SwaggerResponse(201, type: typeof(SuccessResponse<RoleDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole([FromBody] RoleCreateDto roleCreateDto)
        {
            var serviceResult = await _roleService.AddRoleAsync(roleCreateDto).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetRoleById), new { id = serviceResult.Id }, serviceResult);
        }

        /// <summary>
        /// Updates an existing role.
        /// </summary>
        /// <param name="id">The ID of the role to update.</param>
        /// <param name="roleUpdateDto">The updated role details.</param>
        /// <returns>Result of the update operation.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<RoleDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPut("update-role/{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] RoleUpdateDto roleUpdateDto)
        {
            var serviceResult = await _roleService.UpdateRoleAsync(id, roleUpdateDto).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Deletes a specific role by ID.
        /// </summary>
        /// <param name="id">The ID of the role to delete.</param>
        /// <returns>Result of the delete operation.</returns>
        [SwaggerResponse(204, description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpDelete("delete-role/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var success = await _roleService.DeleteRoleAsync(id).ConfigureAwait(false);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
