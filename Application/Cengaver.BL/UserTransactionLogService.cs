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
        private readonly IGenericRepository<UserTransactionLog> _transactionLogRepository;
        private readonly IMapper _mapper;

        public UserTransactionLogService(IGenericRepository<UserTransactionLog> transactionLogRepository, IMapper mapper)
        {
            _transactionLogRepository = transactionLogRepository;
            _mapper = mapper;
        }

        public async Task<List<UserTransactionLogDto>> GetUserTransactionLogsAsync()
        {
            var logs = await _transactionLogRepository.GetAllAsync().ConfigureAwait(false);
            return _mapper.Map<List<UserTransactionLogDto>>(logs);
        }

        public async Task<UserTransactionLogDto> GetUserTransactionLogByIdAsync(int id)
        {
            var log = await _transactionLogRepository.GetByIdAsync(id).ConfigureAwait(false);
            return log == null ? null : _mapper.Map<UserTransactionLogDto>(log);
        }

        public async Task<UserTransactionLogDto> AddUserTransactionLogAsync(UserTransactionLogCreateDto transactionLogDto)
        {
            var transactionLog = _mapper.Map<UserTransactionLog>(transactionLogDto);
            await _transactionLogRepository.AddAsync(transactionLog).ConfigureAwait(false);
            return _mapper.Map<UserTransactionLogDto>(transactionLog);
        }

        public async Task<UserTransactionLogDto> UpdateUserTransactionLogAsync(int id, UserTransactionLogDto transactionLogDto)
        {
            var existingLog = await _transactionLogRepository.GetByIdAsync(id).ConfigureAwait(false);
            if (existingLog == null)
                return null;

            _mapper.Map(transactionLogDto, existingLog);
            await _transactionLogRepository.UpdateAsync(existingLog).ConfigureAwait(false);
            return _mapper.Map<UserTransactionLogDto>(existingLog);
        }

        public async Task<bool> DeleteUserTransactionLogAsync(int id)
        {
            var existingLog = await _transactionLogRepository.GetByIdAsync(id).ConfigureAwait(false);
            if (existingLog == null)
                return false;

            await _transactionLogRepository.DeleteAsync(existingLog).ConfigureAwait(false);
            return true;
        }
    }

}
