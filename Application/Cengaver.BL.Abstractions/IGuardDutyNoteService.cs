using Cengaver.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{
    public interface IGuardDutyNoteService
    {
        Task<IEnumerable<GuardDutyNote>> GetAllAsync();
        Task<GuardDutyNote> GetByIdAsync(int id);
        Task AddAsync(GuardDutyNote note);
        Task UpdateAsync(GuardDutyNote note);
        Task DeleteAsync(int id);
    }
}
