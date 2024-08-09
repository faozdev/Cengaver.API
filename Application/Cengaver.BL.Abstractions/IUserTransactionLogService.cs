using Cengaver.Domain;
using Cengaver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{
    public interface IUserTransactionLogService
    {
        Task<List<UserTransactionLogDto>> GetUserTransactionLogsAsync();
        Task<UserTransactionLogDto> GetUserTransactionLogByIdAsync(int id);
        Task<UserTransactionLogDto> AddUserTransactionLogAsync(UserTransactionLogCreateDto transactionLogDto);
        Task<UserTransactionLogDto> UpdateUserTransactionLogAsync(int id, UserTransactionLogDto transactionLogDto);
        Task<bool> DeleteUserTransactionLogAsync(int id);
    }
}
