using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cengaver.Domain;
using Cengaver.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cengaver.Infrastructure.Repository
{


    public class GuardDutyBreakRepository : IGuardDutyBreakRepository
    {
        private readonly DataContext _context;

        public GuardDutyBreakRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<GuardDutyBreak>> GetAllAsync()
        {
            return await _context.GuardDutyBreaks.ToListAsync().ConfigureAwait(false);
        }

        public async Task<GuardDutyBreak> GetByIdAsync(int id)
        {
            return await _context.GuardDutyBreaks
                                 .Include(g => g.User) // Assuming you want to include related entities
                                 .Include(g => g.GuardDutyBreakType) // Assuming you want to include related entities
                                 .FirstOrDefaultAsync(g => g.Id == id)
                                 .ConfigureAwait(false);
        }

        public async Task<List<GuardDutyBreak>> GetByUserIdAsync(string userId)
        {
            return await _context.GuardDutyBreaks
                                 .Where(g => g.UserId == userId)
                                 .Include(g => g.User)
                                 .Include(g => g.GuardDutyBreakType)
                                 .ToListAsync()
                                 .ConfigureAwait(false);
        }

        public async Task<GuardDutyBreak> AddAsync(GuardDutyBreak guardDutyBreak)
        {
            await _context.GuardDutyBreaks.AddAsync(guardDutyBreak).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return guardDutyBreak;
        }

        public async Task<GuardDutyBreak> UpdateAsync(GuardDutyBreak guardDutyBreak)
        {
            _context.GuardDutyBreaks.Update(guardDutyBreak);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return guardDutyBreak;
        }

        public async Task DeleteAsync(int id)
        {
            var guardDutyBreak = await _context.GuardDutyBreaks.FindAsync(id).ConfigureAwait(false);
            if (guardDutyBreak != null)
            {
                _context.GuardDutyBreaks.Remove(guardDutyBreak);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }


}
