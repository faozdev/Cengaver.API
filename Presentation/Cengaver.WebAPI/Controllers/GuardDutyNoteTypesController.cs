using Cengaver.Domain;
using Cengaver.BL;
using Cengaver.BL.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Cengaver.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuardDutyNoteTypesController : ControllerBase
    {
        private readonly IGuardDutyNoteTypeService _guardDutyNoteTypeService;

        public GuardDutyNoteTypesController(IGuardDutyNoteTypeService guardDutyNoteTypeService)
        {
            _guardDutyNoteTypeService = guardDutyNoteTypeService;
        }

        // GET: api/GuardDutyNoteTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuardDutyNoteType>>> GetGuardDutyNoteTypes()
        {
            var noteTypes = await _guardDutyNoteTypeService.GetAllAsync();
            return Ok(noteTypes);
        }

        // GET: api/GuardDutyNoteTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuardDutyNoteType>> GetGuardDutyNoteTypeById(int id)
        {
            var noteType = await _guardDutyNoteTypeService.GetByIdAsync(id);

            if (noteType == null)
            {
                return NotFound();
            }

            return Ok(noteType);
        }

        // POST: api/GuardDutyNoteTypes
        [HttpPost]
        public async Task<ActionResult<GuardDutyNoteType>> PostGuardDutyNoteType(GuardDutyNoteType noteType)
        {
            await _guardDutyNoteTypeService.AddAsync(noteType);
            return CreatedAtAction(nameof(GetGuardDutyNoteTypeById), new { id = noteType.NoteTypeId }, noteType);
        }

        // PUT: api/GuardDutyNoteTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuardDutyNoteType(int id, GuardDutyNoteType noteType)
        {
            if (id != noteType.NoteTypeId)
            {
                return BadRequest();
            }

            await _guardDutyNoteTypeService.UpdateAsync(noteType);
            return NoContent();
        }

        // DELETE: api/GuardDutyNoteTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuardDutyNoteType(int id)
        {
            await _guardDutyNoteTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
