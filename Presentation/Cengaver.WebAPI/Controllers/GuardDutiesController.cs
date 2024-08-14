using AutoMapper;
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
    public class GuardDutiesController : ControllerBase
    {
        private readonly IGuardDutyService _guardDutyService;

        public GuardDutiesController(IGuardDutyService guardDutyService)
        {
            _guardDutyService = guardDutyService;
        }

        /// <summary>
        /// Gets the list of all guard duties.
        /// </summary>
        /// <returns>List of guard duties.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<GuardDutyDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-guard-duties")]
        public async Task<IActionResult> GetGuardDuties()
        {
            var serviceResult = await _guardDutyService.GetGuardDutiesAsync().ConfigureAwait(false);
            return Ok(serviceResult);
        }

        /// <summary>
        /// Gets a specific guard duty by ID.
        /// </summary>
        /// <param name="id">The ID of the guard duty.</param>
        /// <returns>Details of the specified guard duty.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<GuardDutyDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-guard-duty/{id}")]
        public async Task<IActionResult> GetGuardDutyById(int id)
        {
            var serviceResult = await _guardDutyService.GetGuardDutyByIdAsync(id).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Gets the list of guard duties assigned to a specific Warden User by their ID.
        /// </summary>
        /// <param name="wardenUserId">The ID of the Warden User.</param>
        /// <returns>List of guard duties assigned to the specified Warden User.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<GuardDutyDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-guard-duties-by-warden/{wardenUserId}")]
        public async Task<IActionResult> GetGuardDutiesByWardenUserId(string wardenUserId)
        {
            var serviceResult = await _guardDutyService.GetGuardDutiesByWardenUserIdAsync(wardenUserId).ConfigureAwait(false);

            if (serviceResult == null || !serviceResult.Any())
                return NotFound();

            return Ok(serviceResult);
        }
        /*
        /// <summary>
        /// Adds a new guard duty.
        /// </summary>
        /// <param name="guardDutyDto">The guard duty details to add.</param>
        /// <returns>Result of the add operation.</returns>
        [SwaggerResponse(201, type: typeof(SuccessResponse<GuardDutyDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPost("add-guard-duty")]
        public async Task<IActionResult> AddGuardDuty([FromBody] GuardDutyDto guardDutyDto)
        {
            var serviceResult = await _guardDutyService.AddGuardDutyAsync(guardDutyDto).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetGuardDutyById), new { id = serviceResult.Id }, serviceResult);
        }
        */
        /// <summary>
        /// Updates an existing guard duty.
        /// </summary>
        /// <param name="id">The ID of the guard duty to update.</param>
        /// <param name="guardDutyDto">The updated guard duty details.</param>
        /// <returns>Result of the update operation.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<GuardDutyDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPut("update-guard-duty/{id}")]
        public async Task<IActionResult> UpdateGuardDuty(int id, [FromBody] GuardDutyDto guardDutyDto)
        {
            var serviceResult = await _guardDutyService.UpdateGuardDutyAsync(id, guardDutyDto).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Deletes a specific guard duty by ID.
        /// </summary>
        /// <param name="id">The ID of the guard duty to delete.</param>
        /// <returns>Result of the delete operation.</returns>
        [SwaggerResponse(204, description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpDelete("delete-guard-duty/{id}")]
        public async Task<IActionResult> DeleteGuardDuty(int id)
        {
            var success = await _guardDutyService.DeleteGuardDutyAsync(id).ConfigureAwait(false);
            if (!success)
                return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Adds a new guard duty.
        /// </summary>
        /// <param name="guardDutyDto">The guard duty details to add.</param>
        /// <returns>Result of the add operation.</returns>
        [SwaggerResponse(201, type: typeof(SuccessResponse<GuardDutyDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPost("add-guard-duty")]
        public async Task<IActionResult> AddGuardDuty([FromBody] GuardDutyDto guardDutyDto)
        {
            var serviceResult = await _guardDutyService.AddGuardDutyAsync(guardDutyDto).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetGuardDutyById), new { id = serviceResult.Id }, serviceResult);
        }

    }


}