using Cengaver.Domain;
using Cengaver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{
    public interface IGuardDutyService
    {
        Task<List<GuardDutyDto>> GetGuardDutiesAsync();
        Task<GuardDutyDto> GetGuardDutyByIdAsync(int id);
        //Task<GuardDutyDto> AddGuardDutyAsync(GuardDutyDto guardDutyDto);
        Task<GuardDutyDto> UpdateGuardDutyAsync(int id, GuardDutyDto guardDutyDto);
        Task<bool> DeleteGuardDutyAsync(int id);
        Task<List<GuardDutyDto>> GetGuardDutiesByWardenUserIdAsync(string wardenUserId);
        Task<GuardDutyDto> AddGuardDutyAsync(GuardDutyDto guardDutyDto);
    }
}
