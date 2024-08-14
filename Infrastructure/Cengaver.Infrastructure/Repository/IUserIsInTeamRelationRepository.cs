using Cengaver.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Infrastructure.Repository
{
    public interface IUserIsInTeamRelationRepository
    {
        /// <summary>
        /// Gets all user-team relations.
        /// </summary>
        /// <returns>A list of user-team relations.</returns>
        Task<List<UserIsInTeamRelation>> GetAllAsync();

        /// <summary>
        /// Gets a specific user-team relation by user ID and team ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="teamId">The ID of the team.</param>
        /// <returns>The user-team relation if found; otherwise, null.</returns>
        Task<UserIsInTeamRelation> GetByIdAsync(string userId, int teamId);

        /// <summary>
        /// Adds a new user-team relation.
        /// </summary>
        /// <param name="relation">The user-team relation to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddAsync(UserIsInTeamRelation relation);

        /// <summary>
        /// Updates an existing user-team relation.
        /// </summary>
        /// <param name="relation">The user-team relation to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateAsync(UserIsInTeamRelation relation);

        /// <summary>
        /// Deletes a user-team relation.
        /// </summary>
        /// <param name="relation">The user-team relation to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(UserIsInTeamRelation relation);

        /// <summary>
        /// Gets all user-team relations for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A list of user-team relations associated with the user.</returns>
        Task<List<UserIsInTeamRelation>> GetByUserIdAsync(string userId);

        /// <summary>
        /// Gets all user-team relations for a specific team.
        /// </summary>
        /// <param name="teamId">The ID of the team.</param>
        /// <returns>A list of user-team relations associated with the team.</returns>
        Task<List<UserIsInTeamRelation>> GetByTeamIdAsync(int teamId);
    }

}
