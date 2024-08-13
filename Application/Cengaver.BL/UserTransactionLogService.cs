using AutoMapper;
using Cengaver.Domain;
using Cengaver.Dto;
using Cengaver.Infrastructure.Extentions;
using Cengaver.Persistence;
using Cengaver.BL.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL   
{
    public class UserTransactionLogService : IUserTransactionLogService
    {
        private readonly DataContext _context;

        public UserTransactionLogService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<UserTransactionLogDto>> GetUserTransactionLogsAsync()
        {
            var logs = await _context.UserTransactionLogs
                .Select(log => new UserTransactionLogDto
                {
                    Id = log.Id,
                    UserId = log.UserId,
                    Type = log.Type,
                    CreatedDate = log.CreatedDate
                })
                .ToListAsync();
            return logs;
        }

        public async Task<UserTransactionLogDto> GetUserTransactionLogByIdAsync(int id)
        {
            var log = await _context.UserTransactionLogs
                .Where(l => l.Id == id)
                .Select(log => new UserTransactionLogDto
                {
                    Id = log.Id,
                    UserId = log.UserId,
                    Type = log.Type,
                    CreatedDate = log.CreatedDate
                })
                .FirstOrDefaultAsync();
            return log;
        }

        public async Task<UserTransactionLogDto> AddUserTransactionLogAsync(UserTransactionLogDto userTransactionLogDto)
        {
            var log = new UserTransactionLog
            {
                UserId = userTransactionLogDto.UserId,
                Type = userTransactionLogDto.Type,
                CreatedDate = userTransactionLogDto.CreatedDate
            };

            _context.UserTransactionLogs.Add(log);
            await _context.SaveChangesAsync();

            userTransactionLogDto.Id = log.Id;
            return userTransactionLogDto;
        }

        public async Task<UserTransactionLogDto> UpdateUserTransactionLogAsync(int id, UserTransactionLogDto userTransactionLogDto)
        {
            var log = await _context.UserTransactionLogs.FindAsync(id);
            if (log == null) return null;

            log.UserId = userTransactionLogDto.UserId;
            log.Type = userTransactionLogDto.Type;
            log.CreatedDate = userTransactionLogDto.CreatedDate;

            _context.UserTransactionLogs.Update(log);
            await _context.SaveChangesAsync();

            return userTransactionLogDto;
        }

        public async Task<bool> DeleteUserTransactionLogAsync(int id)
        {
            var log = await _context.UserTransactionLogs.FindAsync(id);
            if (log == null) return false;

            _context.UserTransactionLogs.Remove(log);
            await _context.SaveChangesAsync();

            return true;
        }
    }


}
