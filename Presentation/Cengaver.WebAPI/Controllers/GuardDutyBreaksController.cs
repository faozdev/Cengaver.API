using Cengaver.Domain;
using Cengaver.BL;
using Cengaver.BL.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Cengaver.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuardDutyBreaksController : ControllerBase
    {
        private readonly IGuardDutyBreakService _guardDutyBreakService;

        public GuardDutyBreaksController(IGuardDutyBreakService guardDutyBreakService)
        {
            _guardDutyBreakService = guardDutyBreakService;
        }

        // GET: api/GuardDutyBreaks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuardDutyBreak>>> GetGuardDutyBreaks()
        {
            var guardDutyBreaks = await _guardDutyBreakService.GetAllAsync();
            return Ok(guardDutyBreaks);
        }

        // GET: api/GuardDutyBreaks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuardDutyBreak>> GetGuardDutyBreakById(int id)
        {
            var guardDutyBreak = await _guardDutyBreakService.GetByIdAsync(id);

            if (guardDutyBreak == null)
            {
                return NotFound();
            }

            return Ok(guardDutyBreak);
        }

        // POST: api/GuardDutyBreaks
        [HttpPost]
        public async Task<ActionResult<GuardDutyBreak>> PostGuardDutyBreak(GuardDutyBreak guardDutyBreak)
        {
            await _guardDutyBreakService.AddAsync(guardDutyBreak);
            return CreatedAtAction(nameof(GetGuardDutyBreakById), new { id = guardDutyBreak.Id }, guardDutyBreak);
        }

        // PUT: api/GuardDutyBreaks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuardDutyBreak(int id, GuardDutyBreak guardDutyBreak)
        {
            if (id != guardDutyBreak.Id)
            {
                return BadRequest();
            }

            await _guardDutyBreakService.UpdateAsync(guardDutyBreak);
            return NoContent();
        }

        // DELETE: api/GuardDutyBreaks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuardDutyBreak(int id)
        {
            await _guardDutyBreakService.DeleteAsync(id);
            return NoContent();
        }
    }
}
