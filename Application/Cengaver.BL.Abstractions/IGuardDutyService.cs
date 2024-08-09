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
        Task<GuardDutyDto> AddGuardDutyAsync(GuardDutyCreateDto guardDutyCreateDto);
        Task<GuardDutyDto> UpdateGuardDutyAsync(int id, GuardDutyDto guardDutyDto);
        Task<bool> DeleteGuardDutyAsync(int id);
    }

}
