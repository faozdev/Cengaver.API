using Cengaver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetRolesAsync();
        Task<RoleDto> GetRoleByIdAsync(int id);
        Task<RoleDto> AddRoleAsync(RoleCreateDto roleCreateDto);
        Task<RoleDto> UpdateRoleAsync(int id, RoleUpdateDto roleUpdateDto);
        Task<bool> DeleteRoleAsync(int id);
    }
}

