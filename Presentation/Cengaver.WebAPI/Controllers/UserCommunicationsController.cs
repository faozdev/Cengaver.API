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

        // GET: api/UserCommunications
        [HttpGet("get-user-communications")]
        public async Task<IActionResult> GetUserCommunications()
        {
            var userCommunications = await _userCommunicationService.GetAllAsync().ConfigureAwait(false);
            return Ok(userCommunications);
        }

        // GET: api/UserCommunications/5/1
        [HttpGet("get-user-communication/{userId}/{communicationTypeId}")]
        public async Task<IActionResult> GetUserCommunication(int userId, int communicationTypeId)
        {
            var userCommunication = await _userCommunicationService.GetByIdAsync(userId, communicationTypeId).ConfigureAwait(false);
            if (userCommunication == null)
                return NotFound();
            return Ok(userCommunication);
        }

        // POST: api/UserCommunications
        [HttpPost("add-user-communication")]
        public async Task<IActionResult> AddUserCommunication([FromBody] UserCommunicationDto userCommunicationDto)
        {
            // Map DTO to domain model
            var userCommunication = new UserCommunication
            {
                UserId = userCommunicationDto.UserId,
                CommunicationTypeId = userCommunicationDto.CommunicationTypeId,
                CommunicationString = userCommunicationDto.CommunicationString
            };

            var serviceResult = await _userCommunicationService.AddAsync(userCommunication).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetUserCommunication), new { userId = serviceResult.UserId, communicationTypeId = serviceResult.CommunicationTypeId }, serviceResult);
        }

        // PUT: api/UserCommunications/5/1
        [HttpPut("update-user-communication/{userId}/{communicationTypeId}")]
        public async Task<IActionResult> UpdateUserCommunication(int userId, int communicationTypeId, [FromBody] UserCommunicationDto userCommunicationDto)
        {
            if (userId != userCommunicationDto.UserId || communicationTypeId != userCommunicationDto.CommunicationTypeId)
                return BadRequest();

            // Map DTO to domain model
            var userCommunication = new UserCommunication
            {
                UserId = userCommunicationDto.UserId,
                CommunicationTypeId = userCommunicationDto.CommunicationTypeId,
                CommunicationString = userCommunicationDto.CommunicationString
            };

            var serviceResult = await _userCommunicationService.UpdateAsync(userCommunication).ConfigureAwait(false);
            if (serviceResult == null)
                return NotFound();
            return Ok(serviceResult);
        }

        // DELETE: api/UserCommunications/5/1
        [HttpDelete("delete-user-communication/{userId}/{communicationTypeId}")]
        public async Task<IActionResult> DeleteUserCommunication(int userId, int communicationTypeId)
        {
            var success = await _userCommunicationService.DeleteAsync(userId, communicationTypeId).ConfigureAwait(false);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }


}
