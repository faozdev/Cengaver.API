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
        private readonly IMapper _mapper;

        public GuardDutiesController(IGuardDutyService guardDutyService, IMapper mapper)
        {
            _guardDutyService = guardDutyService;
            _mapper = mapper;
        }

        [SwaggerResponse(200, type: typeof(SuccessResponse<List<GuardDutyDto>>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-guard-duties")]
        public async Task<IActionResult> GetGuardDuties()
        {
            var guardDuties = await _guardDutyService.GetGuardDutiesAsync().ConfigureAwait(false);
            return Ok(new SuccessResponse<List<GuardDutyDto>> { Data = guardDuties });
        }

        [SwaggerResponse(200, type: typeof(SuccessResponse<GuardDutyDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpGet("get-guard-duty/{id}")]
        public async Task<IActionResult> GetGuardDutyById(int id)
        {
            var guardDuty = await _guardDutyService.GetGuardDutyByIdAsync(id).ConfigureAwait(false);
            if (guardDuty == null)
                return NotFound();

            return Ok(new SuccessResponse<GuardDutyDto> { Data = guardDuty });
        }

        [SwaggerResponse(201, type: typeof(SuccessResponse<GuardDutyDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPost("add-guard-duty")]
        public async Task<IActionResult> AddGuardDuty([FromBody] GuardDutyCreateDto guardDutyCreateDto)
        {
            var guardDutyDto = await _guardDutyService.AddGuardDutyAsync(guardDutyCreateDto).ConfigureAwait(false);
            if (guardDutyDto == null)
                return BadRequest("Error creating GuardDuty.");

            return CreatedAtAction(nameof(GetGuardDutyById), new { id = guardDutyDto.Id }, new SuccessResponse<GuardDutyDto> { Data = guardDutyDto });
        }

        [SwaggerResponse(200, type: typeof(SuccessResponse<GuardDutyDto>), description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(422, type: typeof(ValidationErrorResponse), description: SwaggerConstants.NotSuccessValidationError)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpPut("update-guard-duty/{id}")]
        public async Task<IActionResult> UpdateGuardDuty(int id, [FromBody] GuardDutyDto guardDutyDto)
        {
            if (id != guardDutyDto.Id)
                return BadRequest();

            var updatedGuardDutyDto = await _guardDutyService.UpdateGuardDutyAsync(id, guardDutyDto).ConfigureAwait(false);
            if (updatedGuardDutyDto == null)
                return NotFound();

            return Ok(new SuccessResponse<GuardDutyDto> { Data = updatedGuardDutyDto });
        }

        [SwaggerResponse(204, description: SwaggerConstants.SuccessMessage)]
        [SwaggerResponse(400, type: typeof(ErrorResponse), description: SwaggerConstants.NotSuccessMessage)]
        [SwaggerResponse(404, type: typeof(ErrorResponse), description: SwaggerConstants.NotFoundMessage)]
        [SwaggerResponse(500, type: typeof(ExceptionResponse), description: SwaggerConstants.ExceptionMessage)]
        [HttpDelete("delete-guard-duty/{id}")]
        public async Task<IActionResult> DeleteGuardDuty(int id)
        {
            var result = await _guardDutyService.DeleteGuardDutyAsync(id).ConfigureAwait(false);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }





}