using Cengaver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{
    public interface IUserRoleService
    {
        /// <summary>
        /// Retrieves all user-role associations.
        /// </summary>
        /// <returns>A list of user-role associations.</returns>
        Task<List<UserRoleDto>> GetUserRolesAsync();

        /// <summary>
        /// Retrieves a specific user-role association by user ID and role ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="roleId">The ID of the role.</param>
        /// <returns>The user-role association details.</returns>
        Task<UserRoleDto> GetUserRoleByIdAsync(string userId, int roleId);

        /// <summary>
        /// Adds a new user-role association.
        /// </summary>
        /// <param name="userRoleCreateDto">The details of the user-role association to add.</param>
        /// <returns>The added user-role association.</returns>
        Task<UserRoleDto> AddUserRoleAsync(UserRoleCreateDto userRoleCreateDto);

        /// <summary>
        /// Updates an existing user-role association.
        /// </summary>
        /// <param name="userId">The ID of the user to update.</param>
        /// <param name="roleId">The ID of the role to update.</param>
        /// <param name="userRoleUpdateDto">The updated user-role association details.</param>
        /// <returns>The updated user-role association.</returns>
        Task<UserRoleDto> UpdateUserRoleAsync(string userId, int roleId, UserRoleUpdateDto userRoleUpdateDto);

        /// <summary>
        /// Deletes a specific user-role association by user ID and role ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="roleId">The ID of the role to delete.</param>
        /// <returns>True if the deletion was successful; otherwise, false.</returns>
        Task<bool> DeleteUserRoleAsync(string userId, int roleId);
    }


}
