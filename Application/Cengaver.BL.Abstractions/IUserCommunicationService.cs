using Cengaver.Domain;
using Cengaver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{
    public interface IUserCommunicationService
    {
        /// <summary>
        /// Gets the list of all user communications.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of user communications.</returns>
        Task<List<UserCommunicationDto>> GetUserCommunicationsAsync();

        /// <summary>
        /// Gets a specific user communication by user ID and communication type ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="communicationTypeId">The ID of the communication type.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the user communication.</returns>
        Task<UserCommunicationDto> GetUserCommunicationByIdAsync(string userId, int communicationTypeId);

        /// <summary>
        /// Adds a new user communication.
        /// </summary>
        /// <param name="userCommunicationDto">The user communication details to add.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added user communication.</returns>
        Task<UserCommunicationDto> AddUserCommunicationAsync(UserCommunicationDto userCommunicationDto);

        /// <summary>
        /// Updates an existing user communication.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="communicationTypeId">The ID of the communication type.</param>
        /// <param name="userCommunicationDto">The updated user communication details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated user communication.</returns>
        Task<UserCommunicationDto> UpdateUserCommunicationAsync(string userId, int communicationTypeId, UserCommunicationDto userCommunicationDto);

        /// <summary>
        /// Deletes a specific user communication by user ID and communication type ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="communicationTypeId">The ID of the communication type.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success or failure.</returns>
        Task<bool> DeleteUserCommunicationAsync(string userId, int communicationTypeId);
        Task<List<UserCommunicationDto>> GetUserCommunicationsByUserIdAsync(string userId);
    }

}
