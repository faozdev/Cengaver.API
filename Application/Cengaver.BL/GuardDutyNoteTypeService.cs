using Cengaver.Domain;
using Cengaver.BL.Abstractions;
using Cengaver.Infrastructure.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL
{
    public class GuardDutyNoteTypeService : IGuardDutyNoteTypeService
    {
        private readonly IGenericRepository<GuardDutyNoteType> _repository;

        public GuardDutyNoteTypeService(IGenericRepository<GuardDutyNoteType> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GuardDutyNoteType>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<GuardDutyNoteType> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(GuardDutyNoteType noteType)
        {
            await _repository.AddAsync(noteType);
        }

        public async Task UpdateAsync(GuardDutyNoteType noteType)
        {
            await _repository.UpdateAsync(noteType);
        }

        public async Task DeleteAsync(int id)
        {
            var noteType = await _repository.GetByIdAsync(id);
            if (noteType != null)
            {
                await _repository.DeleteAsync(id); 
            }
        }
    }
}
