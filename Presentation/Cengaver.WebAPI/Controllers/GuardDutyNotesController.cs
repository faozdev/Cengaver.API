using Cengaver.Domain;
using Cengaver.BL;
using Cengaver.BL.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Cengaver.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuardDutyNotesController : ControllerBase
    {
        private readonly IGuardDutyNoteService _guardDutyNoteService;

        public GuardDutyNotesController(IGuardDutyNoteService guardDutyNoteService)
        {
            _guardDutyNoteService = guardDutyNoteService;
        }

        // GET: api/GuardDutyNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuardDutyNote>>> GetGuardDutyNotes()
        {
            var notes = await _guardDutyNoteService.GetAllAsync();
            return Ok(notes);
        }

        // GET: api/GuardDutyNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuardDutyNote>> GetGuardDutyNoteById(int id)
        {
            var note = await _guardDutyNoteService.GetByIdAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        // POST: api/GuardDutyNotes
        [HttpPost]
        public async Task<ActionResult<GuardDutyNote>> PostGuardDutyNote(GuardDutyNote note)
        {
            await _guardDutyNoteService.AddAsync(note);
            return CreatedAtAction(nameof(GetGuardDutyNoteById), new { id = note.Id }, note);
        }

        // PUT: api/GuardDutyNotes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuardDutyNote(int id, GuardDutyNote note)
        {
            if (id != note.Id)
            {
                return BadRequest();
            }

            await _guardDutyNoteService.UpdateAsync(note);
            return NoContent();
        }

        // DELETE: api/GuardDutyNotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuardDutyNote(int id)
        {
            await _guardDutyNoteService.DeleteAsync(id);
            return NoContent();
        }
    }
}
