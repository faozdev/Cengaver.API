using Cengaver.Dto;
using Cengaver.WebAPI.Model;
using Cengaver.WebAPI.Swagger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Cengaver.BL.Abstractions;

namespace Cengaver.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserIsInTeamRelationController : ControllerBase
    {
        private readonly IUserIsInTeamRelationService _userIsInTeamRelationService;

        public UserIsInTeamRelationController(IUserIsInTeamRelationService userIsInTeamRelationService)
        {
            _userIsInTeamRelationService = userIsInTeamRelationService;
        }

        /// <summary>
        /// Gets the list of all user-team relations.
        /// </summary>
        /// <returns>List of user-team relations.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<UserIsInTeamRelationDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-user-team-relations")]
        public async Task<IActionResult> GetUserTeamRelations()
        {
            var serviceResult = await _userIsInTeamRelationService.GetUserTeamRelationsAsync().ConfigureAwait(false);
            return Ok(serviceResult);
        }

        /// <summary>
        /// Gets a specific user-team relation by user ID and team ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="teamId">The ID of the team.</param>
        /// <returns>Details of the specified user-team relation.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<UserIsInTeamRelationDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-user-team-relation/{userId}/{teamId}")]
        public async Task<IActionResult> GetUserTeamRelationById(string userId, int teamId)
        {
            var serviceResult = await _userIsInTeamRelationService.GetUserTeamRelationByIdAsync(userId, teamId).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Adds a new user-team relation.
        /// </summary>
        /// <param name="userIsInTeamRelationCreateDto">The user-team relation details to add.</param>
        /// <returns>Result of the add operation.</returns>
        [SwaggerResponse(201, type: typeof(SuccessResponse<UserIsInTeamRelationDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPost("add-user-team-relation")]
        public async Task<IActionResult> AddUserTeamRelation([FromBody] UserIsInTeamRelationCreateDto userIsInTeamRelationCreateDto)
        {
            var serviceResult = await _userIsInTeamRelationService.AddUserTeamRelationAsync(userIsInTeamRelationCreateDto).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetUserTeamRelationById), new { userId = serviceResult.UserId, teamId = serviceResult.TeamId }, serviceResult);
        }

        /// <summary>
        /// Updates an existing user-team relation.
        /// </summary>
        /// <param name="userId">The ID of the user to update.</param>
        /// <param name="teamId">The ID of the team to update.</param>
        /// <param name="userIsInTeamRelationUpdateDto">The updated user-team relation details.</param>
        /// <returns>Result of the update operation.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<UserIsInTeamRelationDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPut("update-user-team-relation/{userId}/{teamId}")]
        public async Task<IActionResult> UpdateUserTeamRelation(string userId, int teamId, [FromBody] UserIsInTeamRelationUpdateDto userIsInTeamRelationUpdateDto)
        {
            var serviceResult = await _userIsInTeamRelationService.UpdateUserTeamRelationAsync(userId, teamId, userIsInTeamRelationUpdateDto).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Deletes a specific user-team relation by user ID and team ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="teamId">The ID of the team to delete.</param>
        /// <returns>Result of the delete operation.</returns>
        [SwaggerResponse(204, description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpDelete("delete-user-team-relation/{userId}/{teamId}")]
        public async Task<IActionResult> DeleteUserTeamRelation(string userId, int teamId)
        {
            var success = await _userIsInTeamRelationService.DeleteUserTeamRelationAsync(userId, teamId).ConfigureAwait(false);
            if (!success)
                return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Gets the list of team relations for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>List of team relations associated with the user.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<UserIsInTeamRelationDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-user-team-relations-by-user/{userId}")]
        public async Task<IActionResult> GetUserTeamRelationsByUser(string userId)
        {
            var serviceResult = await _userIsInTeamRelationService.GetUserTeamRelationsByUserIdAsync(userId).ConfigureAwait(false);
            if (serviceResult == null || !serviceResult.Any())
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Gets the list of team IDs for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>List of team IDs associated with the user.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<int>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-team-ids-by-user/{userId}")]
        public async Task<IActionResult> GetTeamIdsByUser(string userId)
        {
            var teamIds = await _userIsInTeamRelationService.GetTeamIdsByUserIdAsync(userId).ConfigureAwait(false);
            if (teamIds == null || !teamIds.Any())
                return NotFound();
            var response = new SuccessResponse<List<int>>(teamIds)
            {
                IsSuccess = true,
                ErrorMessage = null
            };
            return Ok(response);
        }
    }
}
