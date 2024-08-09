using Cengaver.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{
    public interface IGuardDutyBreakService
    {
        Task<IEnumerable<GuardDutyBreak>> GetAllAsync();
        Task<GuardDutyBreak> GetByIdAsync(int id);
        Task AddAsync(GuardDutyBreak guardDutyBreak);
        Task UpdateAsync(GuardDutyBreak guardDutyBreak);
        Task DeleteAsync(int id);
    }

}
