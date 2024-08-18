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
        Task<List<PermissionDto>> GetPermissionsAsync();
        Task<PermissionDto> GetPermissionByIdAsync(int id);
        Task<PermissionDto> AddPermissionAsync(PermissionDto permissionDto);
        Task<PermissionDto> UpdatePermissionAsync(int id, PermissionDto permissionDto);
        Task<bool> DeletePermissionAsync(int id);
        Task<List<PermissionDto>> GetPermissionsByRoleIdAsync(int roleId);
    }
}
