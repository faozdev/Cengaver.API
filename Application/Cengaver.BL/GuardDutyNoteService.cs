using Cengaver.Domain;
using Cengaver.BL.Abstractions;
using System;
using Cengaver.Infrastructure.Extentions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL
{
    public class GuardDutyNoteService : IGuardDutyNoteService
    {
        private readonly IGenericRepository<GuardDutyNote> _repository;

        public GuardDutyNoteService(IGenericRepository<GuardDutyNote> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GuardDutyNote>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<GuardDutyNote> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(GuardDutyNote note)
        {
            await _repository.AddAsync(note);
        }

        public async Task UpdateAsync(GuardDutyNote note)
        {
            await _repository.UpdateAsync(note);
        }

        public async Task DeleteAsync(int id)
        {
            var note = await _repository.GetByIdAsync(id);
            if (note != null)
            {
                note.IsDeleted = true;
                await _repository.UpdateAsync(note);
            }
        }
    }
}
