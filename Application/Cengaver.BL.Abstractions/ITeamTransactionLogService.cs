using Cengaver.Domain;
using Cengaver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{
    public interface ITeamTransactionLogService
    {
        Task<IEnumerable<TeamTransactionLogDto>> GetTeamTransactionsAsync();
        Task<TeamTransactionLogDto> GetTeamTransactionByIdAsync(int id);
        Task<TeamTransactionLogDto> AddTeamTransactionAsync(TeamTransactionLogDto teamTransactionLogDto);
        Task<TeamTransactionLogDto> UpdateTeamTransactionAsync(int id, TeamTransactionLogDto teamTransactionLogDto);
        Task<bool> DeleteTeamTransactionAsync(int id);
    }
}
