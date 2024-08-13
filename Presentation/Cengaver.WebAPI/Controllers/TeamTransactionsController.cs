using Cengaver.Domain;
using Cengaver.BL;
using Cengaver.BL.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Cengaver.WebAPI.Model;
using Cengaver.WebAPI.Swagger;
using Swashbuckle.AspNetCore.Annotations;
using Cengaver.Dto;

namespace Cengaver.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamTransactionsController : ControllerBase
    {
        private readonly ITeamTransactionLogService _teamTransactionService;

        public TeamTransactionsController(ITeamTransactionLogService teamTransactionService)
        {
            _teamTransactionService = teamTransactionService;
        }

        /// <summary>
        /// Gets the list of all team transactions.
        /// </summary>
        /// <returns>List of team transactions.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<TeamTransactionLogDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-team-transactions")]
        public async Task<IActionResult> GetTeamTransactions()
        {
            var serviceResult = await _teamTransactionService.GetTeamTransactionsAsync().ConfigureAwait(false);
            return Ok(serviceResult);
        }

        /// <summary>
        /// Gets a specific team transaction by ID.
        /// </summary>
        /// <param name="id">The ID of the team transaction.</param>
        /// <returns>Details of the specified team transaction.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<TeamTransactionLogDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-team-transaction/{id}")]
        public async Task<IActionResult> GetTeamTransactionById(int id)
        {
            var serviceResult = await _teamTransactionService.GetTeamTransactionByIdAsync(id).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Adds a new team transaction.
        /// </summary>
        /// <param name="teamTransactionLogDto">The team transaction details to add.</param>
        /// <returns>Result of the add operation.</returns>
        [SwaggerResponse(201, type: typeof(SuccessResponse<TeamTransactionLogDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPost("add-team-transaction")]
        public async Task<IActionResult> AddTeamTransaction([FromBody] TeamTransactionLogDto teamTransactionLogDto)
        {
            var serviceResult = await _teamTransactionService.AddTeamTransactionAsync(teamTransactionLogDto).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetTeamTransactionById), new { id = serviceResult.Id }, serviceResult);
        }

        /// <summary>
        /// Updates an existing team transaction.
        /// </summary>
        /// <param name="id">The ID of the team transaction to update.</param>
        /// <param name="teamTransactionLogDto">The updated team transaction details.</param>
        /// <returns>Result of the update operation.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<TeamTransactionLogDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPut("update-team-transaction/{id}")]
        public async Task<IActionResult> UpdateTeamTransaction(int id, [FromBody] TeamTransactionLogDto teamTransactionLogDto)
        {
            var serviceResult = await _teamTransactionService.UpdateTeamTransactionAsync(id, teamTransactionLogDto).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Deletes a specific team transaction by ID.
        /// </summary>
        /// <param name="id">The ID of the team transaction to delete.</param>
        /// <returns>Result of the delete operation.</returns>
        [SwaggerResponse(204, description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpDelete("delete-team-transaction/{id}")]
        public async Task<IActionResult> DeleteTeamTransaction(int id)
        {
            var success = await _teamTransactionService.DeleteTeamTransactionAsync(id).ConfigureAwait(false);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }

}
