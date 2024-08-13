using AutoMapper;
using Cengaver.Domain;
using Cengaver.Dto;
using Cengaver.BL.Abstractions;
using Cengaver.Infrastructure.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cengaver.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cengaver.BL
{
    public class PermissionService : IPermissionService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper; // Assuming you use AutoMapper for DTO mapping

        public PermissionService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PermissionDto>> GetPermissionsAsync()
        {
            var permissions = await _context.Permissions.ToListAsync();
            return _mapper.Map<List<PermissionDto>>(permissions);
        }

        public async Task<PermissionDto> GetPermissionByIdAsync(int id)
        {
            var permission = await _context.Permissions
                .FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<PermissionDto>(permission);
        }

        public async Task<List<PermissionDto>> GetPermissionsByRoleIdAsync(int roleId)
        {
            var permissions = await _context.Permissions
                .Where(p => p.RoleId == roleId)
                .ToListAsync();
            return _mapper.Map<List<PermissionDto>>(permissions);
        }

        public async Task<PermissionDto> AddPermissionAsync(PermissionDto permissionDto)
        {
            var permission = _mapper.Map<Permission>(permissionDto);
            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();
            return _mapper.Map<PermissionDto>(permission);
        }

        public async Task<PermissionDto> UpdatePermissionAsync(int id, PermissionDto permissionDto)
        {
            var existingPermission = await _context.Permissions
                .FirstOrDefaultAsync(p => p.Id == id);
            if (existingPermission == null)
            {
                return null; // Or throw a custom exception
            }

            _mapper.Map(permissionDto, existingPermission);
            _context.Permissions.Update(existingPermission);
            await _context.SaveChangesAsync();
            return _mapper.Map<PermissionDto>(existingPermission);
        }

        public async Task<bool> DeletePermissionAsync(int id)
        {
            var existingPermission = await _context.Permissions
                .FirstOrDefaultAsync(p => p.Id == id);
            if (existingPermission == null)
            {
                return false; // Or throw a custom exception
            }

            _context.Permissions.Remove(existingPermission);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
