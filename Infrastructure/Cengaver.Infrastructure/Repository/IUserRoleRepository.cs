using Cengaver.Domain;
using Cengaver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Infrastructure.Repository
{
    public interface IUserRoleRepository
    {
        Task<List<UserRoleDto>> GetAllAsync();
        Task<UserRoleDto> GetByIdAsync(string userId, int roleId);
        Task AddAsync(UserRoleCreateDto userRoleCreateDto);
        Task UpdateAsync(UserRoleUpdateDto userRoleUpdateDto);
        Task DeleteAsync(string userId, int roleId);
    }
}
