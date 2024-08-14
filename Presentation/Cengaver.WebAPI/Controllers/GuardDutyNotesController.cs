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
    public class GuardDutyNotesController : ControllerBase
    {
        private readonly IGuardDutyNoteService _guardDutyNoteService;

        public GuardDutyNotesController(IGuardDutyNoteService guardDutyNoteService)
        {
            _guardDutyNoteService = guardDutyNoteService;
        }

        /// <summary>
        /// Gets the list of all guard duty notes.
        /// </summary>
        /// <returns>List of guard duty notes.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<GuardDutyNoteDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-guard-duty-notes")]
        public async Task<IActionResult> GetGuardDutyNotes()
        {
            var serviceResult = await _guardDutyNoteService.GetGuardDutyNotesAsync().ConfigureAwait(false);
            return Ok(serviceResult);
        }

        /// <summary>
        /// Gets a specific guard duty note by ID.
        /// </summary>
        /// <param name="id">The ID of the guard duty note.</param>
        /// <returns>Details of the specified guard duty note.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<GuardDutyNoteDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-guard-duty-note/{id}")]
        public async Task<IActionResult> GetGuardDutyNoteById(int id)
        {
            var serviceResult = await _guardDutyNoteService.GetGuardDutyNoteByIdAsync(id).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Gets the list of guard duty notes by Guard Duty ID.
        /// </summary>
        /// <param name="guardDutyId">The Guard Duty ID to filter notes.</param>
        /// <returns>List of guard duty notes associated with the given Guard Duty ID.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<GuardDutyNoteDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-guard-duty-notes-by-guard-duty/{guardDutyId}")]
        public async Task<IActionResult> GetGuardDutyNotesByGuardDutyId(int guardDutyId)
        {
            var serviceResult = await _guardDutyNoteService.GetGuardDutyNotesByGuardDutyIdAsync(guardDutyId).ConfigureAwait(false);
            if (serviceResult == null || !serviceResult.Any())
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Adds a new guard duty note.
        /// </summary>
        /// <param name="guardDutyNoteDto">The guard duty note details to add.</param>
        /// <returns>Result of the add operation.</returns>
        [SwaggerResponse(201, type: typeof(SuccessResponse<GuardDutyNoteDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPost("add-guard-duty-note")]
        public async Task<IActionResult> AddGuardDutyNote([FromBody] GuardDutyNoteDto guardDutyNoteDto)
        {
            var serviceResult = await _guardDutyNoteService.AddGuardDutyNoteAsync(guardDutyNoteDto).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetGuardDutyNoteById), new { id = serviceResult.Id }, serviceResult);
        }

        /// <summary>
        /// Updates an existing guard duty note.
        /// </summary>
        /// <param name="id">The ID of the guard duty note to update.</param>
        /// <param name="guardDutyNoteDto">The updated guard duty note details.</param>
        /// <returns>Result of the update operation.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<GuardDutyNoteDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPut("update-guard-duty-note/{id}")]
        public async Task<IActionResult> UpdateGuardDutyNote(int id, [FromBody] GuardDutyNoteDto guardDutyNoteDto)
        {
            var serviceResult = await _guardDutyNoteService.UpdateGuardDutyNoteAsync(id, guardDutyNoteDto).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Deletes a specific guard duty note by ID.
        /// </summary>
        /// <param name="id">The ID of the guard duty note to delete.</param>
        /// <returns>Result of the delete operation.</returns>
        [SwaggerResponse(204, description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpDelete("delete-guard-duty-note/{id}")]
        public async Task<IActionResult> DeleteGuardDutyNote(int id)
        {
            var success = await _guardDutyNoteService.DeleteGuardDutyNoteAsync(id).ConfigureAwait(false);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }

}
