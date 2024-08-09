using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cengaver.Dto;
using Cengaver.WebAPI.Model;
using Cengaver.BL;
using Cengaver.BL.Abstractions;
using Cengaver.WebAPI.Swagger;

namespace Cengaver.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        /// <summary>
        /// Gets the list of all teams.
        /// </summary>
        /// <returns>List of teams.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<TeamDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-teams")]
        public async Task<IActionResult> GetTeams()
        {
            var serviceResult = await _teamService.GetTeamsAsync().ConfigureAwait(false);
            return Ok(serviceResult); 
        }

        /// <summary>
        /// Gets a specific team by ID.
        /// </summary>
        /// <param name="id">The ID of the team.</param>
        /// <returns>Details of the specified team.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<TeamDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-team/{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var serviceResult = await _teamService.GetTeamByIdAsync(id).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound(); 
            return Ok(serviceResult); 
        }

        /// <summary>
        /// Adds a new team.
        /// </summary>
        /// <param name="teamDto">The team details to add.</param>
        /// <returns>Result of the add operation.</returns>
        [SwaggerResponse(201, type: typeof(SuccessResponse<TeamDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPost("add-team")]
        public async Task<IActionResult> AddTeam([FromBody] TeamDto teamDto)
        {
            var serviceResult = await _teamService.AddTeamAsync(teamDto).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetTeamById), new { id = serviceResult.Id }, serviceResult); 
        }

        /// <summary>
        /// Updates an existing team.
        /// </summary>
        /// <param name="id">The ID of the team to update.</param>
        /// <param name="teamDto">The updated team details.</param>
        /// <returns>Result of the update operation.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<TeamDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPut("update-team/{id}")]
        public async Task<IActionResult> UpdateTeam(int id, [FromBody] TeamDto teamDto)
        {
            var serviceResult = await _teamService.UpdateTeamAsync(id, teamDto).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound(); 
            return Ok(serviceResult); 
        }

        /// <summary>
        /// Deletes a specific team by ID.
        /// </summary>
        /// <param name="id">The ID of the team to delete.</param>
        /// <returns>Result of the delete operation.</returns>
        [SwaggerResponse(204, description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpDelete("delete-team/{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var success = await _teamService.DeleteTeamAsync(id).ConfigureAwait(false);
            if (!success)
                return NotFound(); 
            return NoContent(); 
        }
    }
}
