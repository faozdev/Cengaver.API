using Cengaver.Domain;
using Cengaver.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Infrastructure.Repository
{
    public class GuardDutyNoteRepository : IGuardDutyNoteRepository
    {
        private readonly DataContext _context;

        public GuardDutyNoteRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<GuardDutyNote>> GetAllAsync()
        {
            return await _context.GuardDutyNotes
                                 .Include(note => note.GuardDuty)
                                 .Include(note => note.NoteType)
                                 .ToListAsync();
        }

        public async Task<GuardDutyNote> GetByIdAsync(int id)
        {
            return await _context.GuardDutyNotes
                                 .Include(note => note.GuardDuty)
                                 .Include(note => note.NoteType)
                                 .FirstOrDefaultAsync(note => note.Id == id);
        }

        public async Task<List<GuardDutyNote>> GetByGuardDutyIdAsync(int guardDutyId)
        {
            return await _context.GuardDutyNotes
                                 .Where(note => note.GuardDutyId == guardDutyId)
                                 .Include(note => note.GuardDuty)
                                 .Include(note => note.NoteType)
                                 .ToListAsync();
        }

        public async Task AddAsync(GuardDutyNote guardDutyNote)
        {
            await _context.GuardDutyNotes.AddAsync(guardDutyNote);
        }

        public void Update(GuardDutyNote guardDutyNote)
        {
            _context.GuardDutyNotes.Update(guardDutyNote);
        }

        public void Delete(GuardDutyNote guardDutyNote)
        {
            _context.GuardDutyNotes.Remove(guardDutyNote);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }

}
