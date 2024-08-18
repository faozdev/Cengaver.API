using Cengaver.Domain;
using Cengaver.Dto;
using Cengaver.Persistence;
using Cengaver.BL.Abstractions;
using Cengaver.Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL
{
    public class RoleService : IRoleService
    {
        private readonly IGenericRepository<Role> _roleRepository;
        private readonly DataContext _dbContext; 

        public RoleService(IGenericRepository<Role> roleRepository, DataContext dbContext)
        {
            _roleRepository = roleRepository;
            _dbContext = dbContext; 
        }

        public async Task<IEnumerable<RoleDto>> GetRolesAsync()
        {
            var roles = await _roleRepository.GetAllAsync();
            return roles.Select(role => new RoleDto
            {
                Id = role.Id,
                RoleName = role.RoleName
            });
        }

        public async Task<RoleDto> GetRoleByIdAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
                return null;

            return new RoleDto
            {
                Id = role.Id,
                RoleName = role.RoleName
            };
        }

        public async Task<RoleDto> AddRoleAsync(RoleCreateDto roleCreateDto)
        {
            var role = new Role
            {
                RoleName = roleCreateDto.RoleName
            };

            await _roleRepository.AddAsync(role);
            await _dbContext.SaveChangesAsync(); 

            return new RoleDto
            {
                Id = role.Id,
                RoleName = role.RoleName
            };
        }

        public async Task<RoleDto> UpdateRoleAsync(int id, RoleUpdateDto roleUpdateDto)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
                return null;

            role.RoleName = roleUpdateDto.RoleName;

            await _roleRepository.UpdateAsync(role);
            await _dbContext.SaveChangesAsync(); 

            return new RoleDto
            {
                Id = role.Id,
                RoleName = role.RoleName
            };
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
                return false;

            await _roleRepository.UpdateAsync(role);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
