using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cengaver.Dto;

namespace Cengaver.BL.Abstractions
{
    public interface IUserTeamService
    {
        /// <summary>
        /// Gets all user-team relationships.
        /// </summary>
        /// <returns>List of user-team relationships.</returns>
        Task<List<UserTeamDto>> GetUserTeamsAsync();

        /// <summary>
        /// Gets all user-team relationships for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>List of teams the user is associated with.</returns>
        Task<List<UserTeamDto>> GetUserTeamsByUserIdAsync(string userId);

        /// <summary>
        /// Adds a new user-team relationship.
        /// </summary>
        /// <param name="userTeamDto">The details of the user-team relationship to add.</param>
        /// <returns>The result of the add operation including the new user-team relationship.</returns>
        Task<UserTeamDto> AddUserToTeamAsync(UserTeamDto userTeamDto);

        /// <summary>
        /// Updates an existing user-team relationship.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="teamId">The ID of the team.</param>
        /// <param name="userTeamDto">The updated user-team relationship details.</param>
        /// <returns>The updated user-team relationship or null if not found.</returns>
        Task<UserTeamDto> UpdateUserTeamAsync(string userId, int teamId, UserTeamDto userTeamDto);

        /// <summary>
        /// Deletes a user from a team.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="teamId">The ID of the team.</param>
        /// <returns>True if the deletion was successful, otherwise false.</returns>
        Task<bool> DeleteUserFromTeamAsync(string userId, int teamId);
    }

}
