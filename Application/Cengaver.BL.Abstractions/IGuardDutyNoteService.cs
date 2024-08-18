using Cengaver.Domain;
using Cengaver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{
    public interface IGuardDutyNoteService
    {
        Task<List<GuardDutyNoteDto>> GetGuardDutyNotesAsync();
        Task<GuardDutyNoteDto> GetGuardDutyNoteByIdAsync(int id);
        Task<List<GuardDutyNoteDto>> GetGuardDutyNotesByGuardDutyIdAsync(int guardDutyId);
        Task<GuardDutyNoteDto> AddGuardDutyNoteAsync(GuardDutyNoteDto guardDutyNoteDto);
        Task<GuardDutyNoteDto> UpdateGuardDutyNoteAsync(int id, GuardDutyNoteDto guardDutyNoteDto);
        Task<bool> DeleteGuardDutyNoteAsync(int id);
    }
}
