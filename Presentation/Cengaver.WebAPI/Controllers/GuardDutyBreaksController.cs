using Cengaver.Domain;
using Cengaver.BL;
using Cengaver.BL.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Cengaver.Dto;
using Cengaver.WebAPI.Model;
using Cengaver.WebAPI.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace Cengaver.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuardDutyBreaksController : ControllerBase
    {
        private readonly IGuardDutyBreakService _guardDutyBreakService;

        public GuardDutyBreaksController(IGuardDutyBreakService guardDutyBreakService)
        {
            _guardDutyBreakService = guardDutyBreakService;
        }

        /// <summary>
        /// Gets the list of all guard duty breaks.
        /// </summary>
        /// <returns>List of guard duty breaks.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<GuardDutyBreakDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-guard-duty-breaks")]
        public async Task<IActionResult> GetGuardDutyBreaks()
        {
            var serviceResult = await _guardDutyBreakService.GetGuardDutyBreaksAsync().ConfigureAwait(false);
            return Ok(serviceResult);
        }

        /// <summary>
        /// Gets a specific guard duty break by ID.
        /// </summary>
        /// <param name="id">The ID of the guard duty break.</param>
        /// <returns>Details of the specified guard duty break.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<GuardDutyBreakDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-guard-duty-break/{id}")]
        public async Task<IActionResult> GetGuardDutyBreakById(int id)
        {
            var serviceResult = await _guardDutyBreakService.GetGuardDutyBreakByIdAsync(id).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Gets the list of guard duty breaks by User ID.
        /// </summary>
        /// <param name="userId">The User ID to filter breaks.</param>
        /// <returns>List of guard duty breaks associated with the given User ID.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<GuardDutyBreakDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-guard-duty-breaks-by-user/{userId}")]
        public async Task<IActionResult> GetGuardDutyBreaksByUserId(string userId)
        {
            var serviceResult = await _guardDutyBreakService.GetGuardDutyBreaksByUserIdAsync(userId).ConfigureAwait(false);
            if (serviceResult == null || !serviceResult.Any())
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Adds a new guard duty break.
        /// </summary>
        /// <param name="guardDutyBreakDto">The guard duty break details to add.</param>
        /// <returns>Result of the add operation.</returns>
        [SwaggerResponse(201, type: typeof(SuccessResponse<GuardDutyBreakDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPost("add-guard-duty-break")]
        public async Task<IActionResult> AddGuardDutyBreak([FromBody] GuardDutyBreakDto guardDutyBreakDto)
        {
            var serviceResult = await _guardDutyBreakService.AddGuardDutyBreakAsync(guardDutyBreakDto).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetGuardDutyBreakById), new { id = serviceResult.Id }, serviceResult);
        }

        /// <summary>
        /// Updates an existing guard duty break.
        /// </summary>
        /// <param name="id">The ID of the guard duty break to update.</param>
        /// <param name="guardDutyBreakDto">The updated guard duty break details.</param>
        /// <returns>Result of the update operation.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<GuardDutyBreakDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPut("update-guard-duty-break/{id}")]
        public async Task<IActionResult> UpdateGuardDutyBreak(int id, [FromBody] GuardDutyBreakDto guardDutyBreakDto)
        {
            var serviceResult = await _guardDutyBreakService.UpdateGuardDutyBreakAsync(id, guardDutyBreakDto).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Deletes a specific guard duty break by ID.
        /// </summary>
        /// <param name="id">The ID of the guard duty break to delete.</param>
        /// <returns>Result of the delete operation.</returns>
        [SwaggerResponse(204, description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpDelete("delete-guard-duty-break/{id}")]
        public async Task<IActionResult> DeleteGuardDutyBreak(int id)
        {
            var success = await _guardDutyBreakService.DeleteGuardDutyBreakAsync(id).ConfigureAwait(false);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }

}
