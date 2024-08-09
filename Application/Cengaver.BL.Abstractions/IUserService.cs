using System.Threading.Tasks;
using System.Collections.Generic;
using Cengaver.Domain;
using Cengaver.Dto;

namespace Cengaver.BL.Abstractions
{
    public interface IUserService
    {
        /// <summary>
        /// Gets the list of all users.
        /// </summary>
        /// <returns>List of users.</returns>
        Task<List<UserDto>> GetUsersAsync();

        /// <summary>
        /// Gets a specific user by ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>Details of the specified user.</returns>
        Task<UserDto> GetUserByIdAsync(int id);

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="userDto">The user details to add.</param>
        /// <returns>Result of the add operation.</returns>
        Task<UserDto> AddUserAsync(UserDto userDto);

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="userDto">The updated user details.</param>
        /// <returns>Result of the update operation.</returns>
        Task<UserDto> UpdateUserAsync(int id, UserDto userDto);

        /// <summary>
        /// Deletes a specific user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>Result of the delete operation.</returns>
        Task<bool> DeleteUserAsync(int id);
    }
}