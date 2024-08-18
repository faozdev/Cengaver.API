using Cengaver.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{
    using Cengaver.Dto;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGuardDutyBreakService
    {
        Task<IEnumerable<GuardDutyBreakDto>> GetGuardDutyBreaksAsync();
        Task<GuardDutyBreakDto> GetGuardDutyBreakByIdAsync(int id);
        Task<List<GuardDutyBreakDto>> GetGuardDutyBreaksByUserIdAsync(string userId);
        Task<GuardDutyBreakDto> AddGuardDutyBreakAsync(GuardDutyBreakDto guardDutyBreakDto);
        Task<GuardDutyBreakDto> UpdateGuardDutyBreakAsync(int id, GuardDutyBreakDto guardDutyBreakDto);
        Task<bool> DeleteGuardDutyBreakAsync(int id);
    }
}
