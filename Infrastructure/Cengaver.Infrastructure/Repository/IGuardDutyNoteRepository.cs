using Cengaver.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Infrastructure.Repository
{
    public interface IGuardDutyNoteRepository
    {
        Task<List<GuardDutyNote>> GetAllAsync();
        Task<GuardDutyNote> GetByIdAsync(int id);
        Task<List<GuardDutyNote>> GetByGuardDutyIdAsync(int guardDutyId);
        Task AddAsync(GuardDutyNote guardDutyNote);
        void Update(GuardDutyNote guardDutyNote);
        void Delete(GuardDutyNote guardDutyNote);
        Task<int> SaveChangesAsync();
    }

}
