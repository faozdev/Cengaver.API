using Cengaver.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{
    public interface ITeamTransactionLogService
    {
        Task<IEnumerable<TeamTransactionLog>> GetAllAsync();
        Task<TeamTransactionLog> GetByIdAsync(int id);
        Task AddAsync(TeamTransactionLog teamTransactionLog);
        Task UpdateAsync(TeamTransactionLog teamTransactionLog);
        Task DeleteAsync(int id);
    }
}
