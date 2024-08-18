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
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-permissions")]
        public async Task<IActionResult> GetPermissions()
        {
            var serviceResult = await _permissionService.GetPermissionsAsync().ConfigureAwait(false);
            return Ok(serviceResult);
        }

        /// <summary>
        /// Gets a specific permission by ID.
        /// </summary>
        /// <param name="id">The ID of the permission.</param>
        /// <returns>Details of the specified permission.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<PermissionDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-permission/{id}")]
        public async Task<IActionResult> GetPermissionById(int id)
        {
            var serviceResult = await _permissionService.GetPermissionByIdAsync(id).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Gets the list of permissions by Role ID.
        /// </summary>
        /// <param name="roleId">The Role ID to filter permissions.</param>
        /// <returns>List of permissions associated with the given Role ID.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<PermissionDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-permissions-by-role/{roleId}")]
        public async Task<IActionResult> GetPermissionsByRoleId(int roleId)
        {
            var serviceResult = await _permissionService.GetPermissionsByRoleIdAsync(roleId).ConfigureAwait(false);
            if (serviceResult == null || !serviceResult.Any())
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
            var serviceResult = await _permissionService.AddPermissionAsync(permissionDto).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetPermissionById), new { id = serviceResult.Id }, serviceResult);
        }

        /// <summary>
        /// Updates an existing permission.
        /// </summary>
        /// <param name="id">The ID of the permission to update.</param>
        /// <param name="permissionDto">The updated permission details.</param>
        /// <returns>Result of the update operation.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<PermissionDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPut("update-permission/{id}")]
        public async Task<IActionResult> UpdatePermission(int id, [FromBody] PermissionDto permissionDto)
        {
            var serviceResult = await _permissionService.UpdatePermissionAsync(id, permissionDto).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Deletes a specific permission by ID.
        /// </summary>
        /// <param name="id">The ID of the permission to delete.</param>
        /// <returns>Result of the delete operation.</returns>
        [SwaggerResponse(204, description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpDelete("delete-permission/{id}")]
        public async Task<IActionResult> DeletePermission(int id)
        {
            var success = await _permissionService.DeletePermissionAsync(id).ConfigureAwait(false);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
