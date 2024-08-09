using Cengaver.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{
    public interface IGuardDutyBreakTypeService
    {
        Task<IEnumerable<GuardDutyBreakType>> GetAllAsync();
        Task<GuardDutyBreakType> GetByIdAsync(int id);
        Task AddAsync(GuardDutyBreakType guardDutyBreakType);
        Task UpdateAsync(GuardDutyBreakType guardDutyBreakType);
        Task DeleteAsync(int id);
    }
}
