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
        Task<UserTransactionLogDto> AddUserTransactionLogAsync(UserTransactionLogDto userTransactionLogDto);
        Task<UserTransactionLogDto> UpdateUserTransactionLogAsync(int id, UserTransactionLogDto userTransactionLogDto);
        Task<bool> DeleteUserTransactionLogAsync(int id);
    }
}
