using Cengaver.Domain;
using Cengaver.Dto;
using Cengaver.BL;
using Cengaver.BL.Abstractions;
using Cengaver.WebAPI.Model;
using Cengaver.WebAPI.Swagger;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Cengaver.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        /// <summary>
        /// Gets the list of all permissions.
        /// </summary>
        /// <returns>List of permissions.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<PermissionDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-permissions")]
        public async Task<IActionResult> GetPermissions()
        {
            var serviceResult = await _permissionService.GetAllAsync().ConfigureAwait(false);
            return Ok(serviceResult); 
        }

        /// <summary>
        /// Gets a specific permission by role ID and permission name.
        /// </summary>
        /// <param name="roleId">The ID of the role.</param>
        /// <param name="userPermission">The name of the permission.</param>
        /// <returns>Details of the specified permission.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<PermissionDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-permission/{roleId}/{userPermission}")]
        public async Task<IActionResult> GetPermission(int roleId, string userPermission)
        {
            var serviceResult = await _permissionService.GetByIdAsync(roleId, userPermission).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound(); 
            return Ok(serviceResult);
        }

        /// <summary>
        /// Adds a new permission.
        /// </summary>
        /// <param name="permissionDto">The permission details to add.</param>
        /// <returns>Result of the add operation.</returns>
        [SwaggerResponse(201, type: typeof(SuccessResponse<PermissionDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPost("add-permission")]
        public async Task<IActionResult> AddPermission([FromBody] PermissionDto permissionDto)
        {
            var serviceResult = await _permissionService.AddAsync(permissionDto).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetPermission), new { roleId = serviceResult.RoleId, userPermission = serviceResult.UserPermission }, serviceResult); // Use CreatedAtAction for creation responses
        }

        /// <summary>
        /// Updates an existing permission.
        /// </summary>
        /// <param name="roleId">The ID of the role to update.</param>
        /// <param name="userPermission">The name of the permission to update.</param>
        /// <param name="permissionDto">The updated permission details.</param>
        /// <returns>Result of the update operation.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<PermissionDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPut("update-permission/{roleId}/{userPermission}")]
        public async Task<IActionResult> UpdatePermission(int roleId, string userPermission, [FromBody] PermissionDto permissionDto)
        {
            if (roleId != permissionDto.RoleId || userPermission != permissionDto.UserPermission)
                return BadRequest(); 

            var serviceResult = await _permissionService.UpdateAsync(permissionDto).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound(); 
            return Ok(serviceResult); 
        }

        /// <summary>
        /// Deletes a specific permission by role ID and permission name.
        /// </summary>
        /// <param name="roleId">The ID of the role.</param>
        /// <param name="userPermission">The name of the permission to delete.</param>
        /// <returns>Result of the delete operation.</returns>
        [SwaggerResponse(204, description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpDelete("delete-permission/{roleId}/{userPermission}")]
        public async Task<IActionResult> DeletePermission(int roleId, string userPermission)
        {
            var success = await _permissionService.DeleteAsync(roleId, userPermission).ConfigureAwait(false);
            if (!success)
                return NotFound(); 
            return NoContent(); 
        }
    }
}
