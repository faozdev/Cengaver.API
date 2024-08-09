using Cengaver.Domain;
using Cengaver.BL;
using Cengaver.BL.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Cengaver.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamTransactionsController : ControllerBase
    {
        private readonly ITeamTransactionLogService _teamTransactionLogService;

        public TeamTransactionsController(ITeamTransactionLogService teamTransactionLogService)
        {
            _teamTransactionLogService = teamTransactionLogService;
        }

        // GET: api/TeamTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamTransactionLog>>> GetTeamTransactions()
        {
            var teamTransactions = await _teamTransactionLogService.GetAllAsync();
            return Ok(teamTransactions);
        }

        // GET: api/TeamTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamTransactionLog>> GetTeamTransaction(int id)
        {
            var teamTransaction = await _teamTransactionLogService.GetByIdAsync(id);

            if (teamTransaction == null)
            {
                return NotFound();
            }

            return Ok(teamTransaction);
        }

        // POST: api/TeamTransactions
        [HttpPost]
        public async Task<ActionResult<TeamTransactionLog>> PostTeamTransaction(TeamTransactionLog teamTransactionLog)
        {
            await _teamTransactionLogService.AddAsync(teamTransactionLog);
            return CreatedAtAction(nameof(GetTeamTransaction), new { id = teamTransactionLog.Id }, teamTransactionLog);
        }

        // PUT: api/TeamTransactions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamTransaction(int id, TeamTransactionLog teamTransactionLog)
        {
            if (id != teamTransactionLog.Id)
            {
                return BadRequest();
            }

            await _teamTransactionLogService.UpdateAsync(teamTransactionLog);
            return NoContent();
        }

        // DELETE: api/TeamTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamTransaction(int id)
        {
            await _teamTransactionLogService.DeleteAsync(id);
            return NoContent();
        }
    }
}
