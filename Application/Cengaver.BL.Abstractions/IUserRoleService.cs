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
        Task<List<UserRoleDto>> GetUserRolesAsync();
        Task<UserRoleDto> GetUserRoleByIdAsync(string userId, int roleId);
        Task<UserRoleDto> AddUserRoleAsync(UserRoleCreateDto userRoleCreateDto);
        Task<UserRoleDto> UpdateUserRoleAsync(string userId, int roleId, UserRoleUpdateDto userRoleUpdateDto);
        Task<bool> DeleteUserRoleAsync(string userId, int roleId);
        Task<List<UserRoleDto>> GetUserRolesByUserIdAsync(string userId);
    }
}
