using Cengaver.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{
    public interface IGuardDutyNoteTypeService
    {
        Task<IEnumerable<GuardDutyNoteType>> GetAllAsync();
        Task<GuardDutyNoteType> GetByIdAsync(int id);
        Task AddAsync(GuardDutyNoteType noteType);
        Task UpdateAsync(GuardDutyNoteType noteType);
        Task DeleteAsync(int id);
    }
}
