using Cengaver.Domain;
using Cengaver.BL.Abstractions;
using Cengaver.Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL
{
    public class GuardDutyBreakService : IGuardDutyBreakService
    {
        private readonly IGenericRepository<GuardDutyBreak> _repository;

        public GuardDutyBreakService(IGenericRepository<GuardDutyBreak> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GuardDutyBreak>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<GuardDutyBreak> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(GuardDutyBreak guardDutyBreak)
        {
            await _repository.AddAsync(guardDutyBreak);
        }

        public async Task UpdateAsync(GuardDutyBreak guardDutyBreak)
        {
            await _repository.UpdateAsync(guardDutyBreak);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }


}
