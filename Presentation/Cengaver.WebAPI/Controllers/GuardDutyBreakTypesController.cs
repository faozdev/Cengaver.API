using Cengaver.Domain;
using Cengaver.BL;
using Cengaver.BL.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cengaver.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuardDutyBreakTypesController : ControllerBase
    {
        private readonly IGuardDutyBreakTypeService _guardDutyBreakTypeService;

        public GuardDutyBreakTypesController(IGuardDutyBreakTypeService guardDutyBreakTypeService)
        {
            _guardDutyBreakTypeService = guardDutyBreakTypeService;
        }

        // GET: api/GuardDutyBreakTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuardDutyBreakType>>> GetGuardDutyBreakTypes()
        {
            var guardDutyBreakTypes = await _guardDutyBreakTypeService.GetAllAsync();
            return Ok(guardDutyBreakTypes);
        }

        // GET: api/GuardDutyBreakTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuardDutyBreakType>> GetGuardDutyBreakTypeById(int id)
        {
            var guardDutyBreakType = await _guardDutyBreakTypeService.GetByIdAsync(id);

            if (guardDutyBreakType == null)
            {
                return NotFound();
            }

            return Ok(guardDutyBreakType);
        }

        // POST: api/GuardDutyBreakTypes
        [HttpPost]
        public async Task<ActionResult<GuardDutyBreakType>> PostGuardDutyBreakType(GuardDutyBreakType guardDutyBreakType)
        {
            await _guardDutyBreakTypeService.AddAsync(guardDutyBreakType);
            return CreatedAtAction(nameof(GetGuardDutyBreakTypeById), new { id = guardDutyBreakType.TypeId }, guardDutyBreakType);
        }

        // PUT: api/GuardDutyBreakTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuardDutyBreakType(int id, GuardDutyBreakType guardDutyBreakType)
        {
            if (id != guardDutyBreakType.TypeId)
            {
                return BadRequest();
            }

            await _guardDutyBreakTypeService.UpdateAsync(guardDutyBreakType);
            return NoContent();
        }

        // DELETE: api/GuardDutyBreakTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuardDutyBreakType(int id)
        {
            await _guardDutyBreakTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
