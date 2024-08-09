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

namespace Cengaver.BL
{
    public class PermissionService : IPermissionService
    {
        private readonly IGenericRepository<Permission> _permissionRepository;
        private readonly IMapper _mapper;

        public PermissionService(IGenericRepository<Permission> permissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionDto>> GetAllAsync()
        {
            var permissions = await _permissionRepository.GetAllAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<PermissionDto>>(permissions);
        }

        public async Task<PermissionDto> GetByIdAsync(int roleId, string userPermission)
        {
            var permission = await _permissionRepository.GetByIdAsync(roleId, userPermission).ConfigureAwait(false);
            return _mapper.Map<PermissionDto>(permission);
        }

        public async Task<PermissionDto> AddAsync(PermissionDto permissionDto)
        {
            var permission = _mapper.Map<Permission>(permissionDto);
            await _permissionRepository.AddAsync(permission).ConfigureAwait(false);
            return permissionDto; // Return the DTO of the newly created permission
        }

        public async Task<PermissionDto> UpdateAsync(PermissionDto permissionDto)
        {
            var permission = _mapper.Map<Permission>(permissionDto);
            await _permissionRepository.UpdateAsync(permission).ConfigureAwait(false);
            return permissionDto; // Return the DTO of the updated permission
        }

        public async Task<bool> DeleteAsync(int roleId, string userPermission)
        {
            try
            {
                await _permissionRepository.DeleteAsync(roleId, userPermission).ConfigureAwait(false);
                return true; // Return true if deletion is successful
            }
            catch (Exception)
            {
                return false; // Return false if any exception occurs
            }
        }
    }
}
