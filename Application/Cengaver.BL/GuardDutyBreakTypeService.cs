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
    public class GuardDutyBreakTypeService : IGuardDutyBreakTypeService
    {
        private readonly IGenericRepository<GuardDutyBreakType> _repository;

        public GuardDutyBreakTypeService(IGenericRepository<GuardDutyBreakType> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GuardDutyBreakType>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<GuardDutyBreakType> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(GuardDutyBreakType guardDutyBreakType)
        {
            await _repository.AddAsync(guardDutyBreakType);
        }

        public async Task UpdateAsync(GuardDutyBreakType guardDutyBreakType)
        {
            await _repository.UpdateAsync(guardDutyBreakType);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
