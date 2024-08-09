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
        Task<IEnumerable<PermissionDto>> GetAllAsync();
        Task<PermissionDto> GetByIdAsync(int roleId, string userPermission);
        Task<PermissionDto> AddAsync(PermissionDto permissionDto);
        Task<PermissionDto> UpdateAsync(PermissionDto permissionDto);
        Task<bool> DeleteAsync(int roleId, string userPermission);
    }
}
