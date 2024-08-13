using Cengaver.WebAPI.Model;
using Cengaver.WebAPI.Swagger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Cengaver.BL.Abstractions;
using Cengaver.Dto;

namespace Cengaver.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTeamsController : ControllerBase
    {
        private readonly IUserTeamService _userTeamService;

        public UserTeamsController(IUserTeamService userTeamService)
        {
            _userTeamService = userTeamService;
        }

        /// <summary>
        /// Gets all user-team relationships.
        /// </summary>
        /// <returns>List of user-team relationships.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<UserTeamDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-user-teams")]
        public async Task<IActionResult> GetUserTeams()
        {
            var serviceResult = await _userTeamService.GetUserTeamsAsync().ConfigureAwait(false);
            return Ok(serviceResult);
        }

        /// <summary>
        /// Gets user-team relationships for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>List of teams the user is associated with.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<UserTeamDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-user-teams/{userId}")]
        public async Task<IActionResult> GetUserTeamsByUserId(string userId)
        {
            var serviceResult = await _userTeamService.GetUserTeamsByUserIdAsync(userId).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Adds a user to a team.
        /// </summary>
        /// <param name="userTeamDto">The user-team relationship details to add.</param>
        /// <returns>Result of the add operation.</returns>
        [SwaggerResponse(201, type: typeof(SuccessResponse<UserTeamDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPost("add-user-team")]
        public async Task<IActionResult> AddUserToTeam([FromBody] UserTeamDto userTeamDto)
        {
            var serviceResult = await _userTeamService.AddUserToTeamAsync(userTeamDto).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetUserTeamsByUserId), new { userId = userTeamDto.UserId }, serviceResult);
        }

        /// <summary>
        /// Updates the user-team relationship.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="teamId">The ID of the team.</param>
        /// <param name="userTeamDto">The updated user-team relationship details.</param>
        /// <returns>Result of the update operation.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<UserTeamDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPut("update-user-team/{userId}/{teamId}")]
        public async Task<IActionResult> UpdateUserTeam(string userId, int teamId, [FromBody] UserTeamDto userTeamDto)
        {
            var serviceResult = await _userTeamService.UpdateUserTeamAsync(userId, teamId, userTeamDto).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Deletes a user from a team.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="teamId">The ID of the team.</param>
        /// <returns>Result of the delete operation.</returns>
        [SwaggerResponse(204, description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpDelete("delete-user-team/{userId}/{teamId}")]
        public async Task<IActionResult> DeleteUserFromTeam(string userId, int teamId)
        {
            var success = await _userTeamService.DeleteUserFromTeamAsync(userId, teamId).ConfigureAwait(false);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }

}
