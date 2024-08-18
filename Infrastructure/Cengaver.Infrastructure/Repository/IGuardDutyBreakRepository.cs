using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cengaver.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cengaver.Infrastructure.Repository
{
    

    public interface IGuardDutyBreakRepository
    {
        Task<List<GuardDutyBreak>> GetAllAsync();
        Task<GuardDutyBreak> GetByIdAsync(int id);
        Task<List<GuardDutyBreak>> GetByUserIdAsync(string userId);
        Task<GuardDutyBreak> AddAsync(GuardDutyBreak guardDutyBreak);
        Task<GuardDutyBreak> UpdateAsync(GuardDutyBreak guardDutyBreak);
        Task DeleteAsync(int id);
    }
}
