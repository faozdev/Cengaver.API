using Cengaver.Domain;
using Cengaver.BL.Abstractions;
using Cengaver.Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cengaver.Dto;
using Cengaver.Persistence;

namespace Cengaver.BL
{
    public class TeamTransactionLogService : ITeamTransactionLogService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TeamTransactionLogService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeamTransactionLogDto>> GetTeamTransactionsAsync()
        {
            var logs = await _context.TeamTransactionLogs.ToListAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<TeamTransactionLogDto>>(logs);
        }

        public async Task<TeamTransactionLogDto> GetTeamTransactionByIdAsync(int id)
        {
            var log = await _context.TeamTransactionLogs.FindAsync(id).ConfigureAwait(false);
            return log == null ? null : _mapper.Map<TeamTransactionLogDto>(log);
        }

        public async Task<TeamTransactionLogDto> AddTeamTransactionAsync(TeamTransactionLogDto teamTransactionLogDto)
        {
            var log = _mapper.Map<TeamTransactionLog>(teamTransactionLogDto);
            _context.TeamTransactionLogs.Add(log);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return _mapper.Map<TeamTransactionLogDto>(log);
        }

        public async Task<TeamTransactionLogDto> UpdateTeamTransactionAsync(int id, TeamTransactionLogDto teamTransactionLogDto)
        {
            var existingLog = await _context.TeamTransactionLogs.FindAsync(id).ConfigureAwait(false);
            if (existingLog == null)
            {
                return null;
            }

            _mapper.Map(teamTransactionLogDto, existingLog);
            _context.TeamTransactionLogs.Update(existingLog);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return _mapper.Map<TeamTransactionLogDto>(existingLog);
        }

        public async Task<bool> DeleteTeamTransactionAsync(int id)
        {
            var log = await _context.TeamTransactionLogs.FindAsync(id).ConfigureAwait(false);
            if (log == null)
            {
                return false;
            }

            _context.TeamTransactionLogs.Remove(log);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }
    }


}
