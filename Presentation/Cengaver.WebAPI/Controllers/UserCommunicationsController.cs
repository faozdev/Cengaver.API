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
    public class UserCommunicationsController : ControllerBase
    {
        private readonly IUserCommunicationService _userCommunicationService;

        public UserCommunicationsController(IUserCommunicationService userCommunicationService)
        {
            _userCommunicationService = userCommunicationService;
        }

        /// <summary>
        /// Gets the list of all user communications.
        /// </summary>
        /// <returns>List of user communications.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<UserCommunicationDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-user-communications")]
        public async Task<IActionResult> GetUserCommunications()
        {
            var serviceResult = await _userCommunicationService.GetUserCommunicationsAsync().ConfigureAwait(false);
            return Ok(serviceResult);
        }

        /// <summary>
        /// Gets a specific user communication by user ID and communication type ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="communicationTypeId">The ID of the communication type.</param>
        /// <returns>Details of the specified user communication.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<UserCommunicationDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-user-communication/{userId}/{communicationTypeId}")]
        public async Task<IActionResult> GetUserCommunication(string userId, int communicationTypeId)
        {
            var serviceResult = await _userCommunicationService.GetUserCommunicationByIdAsync(userId, communicationTypeId).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Adds a new user communication.
        /// </summary>
        /// <param name="userCommunicationDto">The user communication details to add.</param>
        /// <returns>Result of the add operation.</returns>
        [SwaggerResponse(201, type: typeof(SuccessResponse<UserCommunicationDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPost("add-user-communication")]
        public async Task<IActionResult> AddUserCommunication([FromBody] UserCommunicationDto userCommunicationDto)
        {
            var serviceResult = await _userCommunicationService.AddUserCommunicationAsync(userCommunicationDto).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetUserCommunication), new { userId = serviceResult.UserId, communicationTypeId = serviceResult.CommunicationTypeId }, serviceResult);
        }

        /// <summary>
        /// Updates an existing user communication.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="communicationTypeId">The ID of the communication type.</param>
        /// <param name="userCommunicationDto">The updated user communication details.</param>
        /// <returns>Result of the update operation.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<UserCommunicationDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPut("update-user-communication/{userId}/{communicationTypeId}")]
        public async Task<IActionResult> UpdateUserCommunication(string userId, int communicationTypeId, [FromBody] UserCommunicationDto userCommunicationDto)
        {
            var serviceResult = await _userCommunicationService.UpdateUserCommunicationAsync(userId, communicationTypeId, userCommunicationDto).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Gets all user communications for a specific user ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>List of user communications for the specified user.</returns>
        [SwaggerResponse(200, type: typeof(SuccessResponse<List<UserCommunicationDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-user-communications/{userId}")]
        public async Task<IActionResult> GetUserCommunicationsByUserId(string userId)
        {
            var serviceResult = await _userCommunicationService.GetUserCommunicationsByUserIdAsync(userId).ConfigureAwait(false);
            if (serviceResult == null || !serviceResult.Any())
                return NotFound();
            return Ok(serviceResult);
        }

        /// <summary>
        /// Deletes a specific user communication by user ID and communication type ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="communicationTypeId">The ID of the communication type.</param>
        /// <returns>Result of the delete operation.</returns>
        [SwaggerResponse(204, description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpDelete("delete-user-communication/{userId}/{communicationTypeId}")]
        public async Task<IActionResult> DeleteUserCommunication(string userId, int communicationTypeId)
        {
            var success = await _userCommunicationService.DeleteUserCommunicationAsync(userId, communicationTypeId).ConfigureAwait(false);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }



}
