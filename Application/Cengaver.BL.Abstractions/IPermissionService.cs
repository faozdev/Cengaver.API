using Cengaver.Domain;
using Cengaver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{

    public interface IPermissionService
    {
        /// <summary>
        /// Gets the list of all permissions.
        /// </summary>
        /// <returns>A list of permissions.</returns>
        Task<List<PermissionDto>> GetPermissionsAsync();

        /// <summary>
        /// Gets a specific permission by ID.
        /// </summary>
        /// <param name="id">The ID of the permission.</param>
        /// <returns>The details of the specified permission.</returns>
        Task<PermissionDto> GetPermissionByIdAsync(int id);

        /// <summary>
        /// Adds a new permission.
        /// </summary>
        /// <param name="permissionDto">The details of the permission to add.</param>
        /// <returns>The result of the add operation, including the ID of the newly created permission.</returns>
        Task<PermissionDto> AddPermissionAsync(PermissionDto permissionDto);

        /// <summary>
        /// Updates an existing permission.
        /// </summary>
        /// <param name="id">The ID of the permission to update.</param>
        /// <param name="permissionDto">The updated details of the permission.</param>
        /// <returns>The updated permission details.</returns>
        Task<PermissionDto> UpdatePermissionAsync(int id, PermissionDto permissionDto);

        /// <summary>
        /// Deletes a specific permission by ID.
        /// </summary>
        /// <param name="id">The ID of the permission to delete.</param>
        /// <returns>A boolean indicating whether the delete operation was successful.</returns>
        Task<bool> DeletePermissionAsync(int id);
    }

}
