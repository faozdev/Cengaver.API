using Cengaver.Domain;
using Cengaver.BL.Abstractions;
using Cengaver.Infrastructure.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL
{
    public class TeamTransactionLogService : ITeamTransactionLogService
    {
        private readonly IGenericRepository<TeamTransactionLog> _teamTransactionLogRepository;

        public TeamTransactionLogService(IGenericRepository<TeamTransactionLog> teamTransactionLogRepository)
        {
            _teamTransactionLogRepository = teamTransactionLogRepository;
        }

        public async Task<IEnumerable<TeamTransactionLog>> GetAllAsync()
        {
            return await _teamTransactionLogRepository.GetAllAsync();
        }

        public async Task<TeamTransactionLog> GetByIdAsync(int id)
        {
            return await _teamTransactionLogRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(TeamTransactionLog teamTransactionLog)
        {
            await _teamTransactionLogRepository.AddAsync(teamTransactionLog);
        }

        public async Task UpdateAsync(TeamTransactionLog teamTransactionLog)
        {
            await _teamTransactionLogRepository.UpdateAsync(teamTransactionLog);
        }

        public async Task DeleteAsync(int id)
        {
            var teamTransactionLog = await _teamTransactionLogRepository.GetByIdAsync(id);
            if (teamTransactionLog != null)
            {
                await _teamTransactionLogRepository.DeleteAsync(id);
            }
        }
    }
}
