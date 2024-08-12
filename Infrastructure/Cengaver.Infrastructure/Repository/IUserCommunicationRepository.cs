using Cengaver.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Infrastructure.Repository
{
    public interface IUserCommunicationRepository
    {
        /// <summary>
        /// Gets all user communications.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of user communications.</returns>
        Task<List<UserCommunication>> GetAllAsync();

        /// <summary>
        /// Gets a specific user communication by user ID and communication type ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="communicationTypeId">The ID of the communication type.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the user communication.</returns>
        Task<UserCommunication> GetByIdAsync(string userId, int communicationTypeId);

        /// <summary>
        /// Adds a new user communication.
        /// </summary>
        /// <param name="userCommunication">The user communication entity to add.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added user communication.</returns>
        Task<UserCommunication> AddAsync(UserCommunication userCommunication);

        /// <summary>
        /// Updates an existing user communication.
        /// </summary>
        /// <param name="userCommunication">The user communication entity to update.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated user communication.</returns>
        Task<UserCommunication> UpdateAsync(UserCommunication userCommunication);

        /// <summary>
        /// Deletes a specific user communication by user ID and communication type ID.
        /// </summary>
        /// <param name="userCommunication">The user communication entity to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteAsync(UserCommunication userCommunication);
    }

}
