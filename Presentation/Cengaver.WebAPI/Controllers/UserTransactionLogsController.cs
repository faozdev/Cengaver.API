using Cengaver.Domain;
using Cengaver.BL;
using Cengaver.BL.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Cengaver.Dto;
using Cengaver.WebAPI.Model;
using Cengaver.WebAPI.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace Cengaver.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTransactionLogsController : ControllerBase
    {
        private readonly IUserTransactionLogService _userTransactionLogService;

        public UserTransactionLogsController(IUserTransactionLogService userTransactionLogService)
        {
            _userTransactionLogService = userTransactionLogService;
        }

        /// <summary>
        /// Gets the list of all user transaction logs.
        /// </summary>
        /// <returns>List of user transaction logs.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<UserTransactionLogDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-logs")]
        public async Task<IActionResult> GetUserTransactionLogs()
        {
            var serviceResult = await _userTransactionLogService.GetUserTransactionLogsAsync().ConfigureAwait(false);
            return Ok(serviceResult);
        }

        /// <summary>
        /// Gets a specific user transaction log by ID.
        /// </summary>
        /// <param name="id">The ID of the transaction log.</param>
        /// <returns>Details of the specified user transaction log.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<UserTransactionLogDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-log/{id}")]
        public async Task<IActionResult> GetUserTransactionLogById(int id)
        {
            var serviceResult = await _userTransactionLogService.GetUserTransactionLogByIdAsync(id).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Adds a new user transaction log.
        /// </summary>
        /// <param name="userTransactionLogDto">The user transaction log details to add.</param>
        /// <returns>Result of the add operation.</returns>
        [SwaggerResponse(201, type: typeof(SuccessResponse<UserTransactionLogDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPost("add-log")]
        public async Task<IActionResult> AddUserTransactionLog([FromBody] UserTransactionLogDto userTransactionLogDto)
        {
            var serviceResult = await _userTransactionLogService.AddUserTransactionLogAsync(userTransactionLogDto).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetUserTransactionLogById), new { id = serviceResult.Id }, serviceResult);
        }

        /// <summary>
        /// Updates an existing user transaction log.
        /// </summary>
        /// <param name="id">The ID of the transaction log to update.</param>
        /// <param name="userTransactionLogDto">The updated user transaction log details.</param>
        /// <returns>Result of the update operation.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<UserTransactionLogDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPut("update-log/{id}")]
        public async Task<IActionResult> UpdateUserTransactionLog(int id, [FromBody] UserTransactionLogDto userTransactionLogDto)
        {
            var serviceResult = await _userTransactionLogService.UpdateUserTransactionLogAsync(id, userTransactionLogDto).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Deletes a specific user transaction log by ID.
        /// </summary>
        /// <param name="id">The ID of the transaction log to delete.</param>
        /// <returns>Result of the delete operation.</returns>
        [SwaggerResponse(204, description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpDelete("delete-log/{id}")]
        public async Task<IActionResult> DeleteUserTransactionLog(int id)
        {
            var success = await _userTransactionLogService.DeleteUserTransactionLogAsync(id).ConfigureAwait(false);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
