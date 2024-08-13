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
        /// <summary>
        /// Gets all user transaction logs.
        /// </summary>
        /// <returns>List of user transaction logs.</returns>
        Task<List<UserTransactionLogDto>> GetUserTransactionLogsAsync();

        /// <summary>
        /// Gets a specific user transaction log by ID.
        /// </summary>
        /// <param name="id">The ID of the user transaction log.</param>
        /// <returns>User transaction log details.</returns>
        Task<UserTransactionLogDto> GetUserTransactionLogByIdAsync(int id);

        /// <summary>
        /// Adds a new user transaction log.
        /// </summary>
        /// <param name="userTransactionLogDto">The details of the user transaction log to add.</param>
        /// <returns>The result of the add operation.</returns>
        Task<UserTransactionLogDto> AddUserTransactionLogAsync(UserTransactionLogDto userTransactionLogDto);

        /// <summary>
        /// Updates an existing user transaction log.
        /// </summary>
        /// <param name="id">The ID of the user transaction log to update.</param>
        /// <param name="userTransactionLogDto">The updated user transaction log details.</param>
        /// <returns>The result of the update operation.</returns>
        Task<UserTransactionLogDto> UpdateUserTransactionLogAsync(int id, UserTransactionLogDto userTransactionLogDto);

        /// <summary>
        /// Deletes a specific user transaction log by ID.
        /// </summary>
        /// <param name="id">The ID of the user transaction log to delete.</param>
        /// <returns>True if the deletion was successful, otherwise false.</returns>
        Task<bool> DeleteUserTransactionLogAsync(int id);
    }

}
