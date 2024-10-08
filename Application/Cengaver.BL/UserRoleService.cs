﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cengaver.BL.Abstractions;
using Microsoft.EntityFrameworkCore;
using Cengaver.Domain;
using Cengaver.Dto;
using Cengaver.Infrastructure.Extentions;
using Cengaver.Infrastructure.Repository;
using Cengaver.Persistence;

namespace Cengaver.BL
{
    public class UserRoleService : IUserRoleService
    {
        private readonly DataContext _context;

        public UserRoleService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<UserRoleDto>> GetUserRolesAsync()
        {
            var userRoles = await _context.UserRoles
                .Include(ur => ur.User)
                .Include(ur => ur.Role)
                .ToListAsync()
                .ConfigureAwait(false);

            return userRoles.Select(ur => new UserRoleDto
            {
                UserId = ur.UserId,
                RoleId = ur.RoleId,
                User = new UserDto
                {
                    Id = ur.User.Id,
                    UserName = ur.User.UserName, 
                    Name = ur.User.Name,
                    SicilNo = ur.User.SicilNo,
                    UserRegistrationDate = ur.User.UserRegistrationDate
                },
                Role = new RoleDto
                {
                    Id = ur.Role.Id,
                    RoleName = ur.Role.RoleName
                }
            }).ToList();
        }

        public async Task<UserRoleDto> GetUserRoleByIdAsync(string userId, int roleId)
        {
            var userRole = await _context.UserRoles
                .Include(ur => ur.User)
                .Include(ur => ur.Role)
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId)
                .ConfigureAwait(false);

            if (userRole == null)
                return null;

            return new UserRoleDto
            {
                UserId = userRole.UserId,
                RoleId = userRole.RoleId,
                User = new UserDto
                {
                    Id = userRole.User.Id,
                    Name = userRole.User.Name 
                                                    
                },
                Role = new RoleDto
                {
                    Id = userRole.Role.Id,
                    RoleName = userRole.Role.RoleName 
                                                      
                }
            };
        }

        public async Task<UserRoleDto> AddUserRoleAsync(UserRoleCreateDto userRoleCreateDto)
        {
            var userRole = new UserRole
            {
                UserId = userRoleCreateDto.UserId,
                RoleId = userRoleCreateDto.RoleId
            };

            _context.UserRoles.Add(userRole);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            var addedUserRole = await _context.UserRoles
                .Include(ur => ur.User)
                .Include(ur => ur.Role)
                .FirstOrDefaultAsync(ur => ur.UserId == userRole.UserId && ur.RoleId == userRole.RoleId)
                .ConfigureAwait(false);

            return new UserRoleDto
            {
                UserId = addedUserRole.UserId,
                RoleId = addedUserRole.RoleId,
                User = new UserDto
                {
                    Id = addedUserRole.User.Id,
                    Name = addedUserRole.User.Name 
                                                           
                },
                Role = new RoleDto
                {
                    Id = addedUserRole.Role.Id,
                    RoleName = addedUserRole.Role.RoleName 
                                                           
                }
            };
        }

        public async Task<UserRoleDto> UpdateUserRoleAsync(string userId, int roleId, UserRoleUpdateDto userRoleUpdateDto)
        {
            var existingUserRole = await _context.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId)
                .ConfigureAwait(false);

            if (existingUserRole == null)
            {
                return null;
            }

            await _context.SaveChangesAsync().ConfigureAwait(false);

            var updatedUserRole = await _context.UserRoles
                .Include(ur => ur.User)
                .Include(ur => ur.Role)
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId)
                .ConfigureAwait(false);

            return new UserRoleDto
            {
                UserId = updatedUserRole.UserId,
                RoleId = updatedUserRole.RoleId,
                User = new UserDto
                {
                    Id = updatedUserRole.User.Id,
                    Name = updatedUserRole.User.Name 
                },
                Role = new RoleDto
                {
                    Id = updatedUserRole.Role.Id,
                    RoleName = updatedUserRole.Role.RoleName 
                }
            };
        }

        public async Task<bool> DeleteUserRoleAsync(string userId, int roleId)
        {
            var userRole = await _context.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId)
                .ConfigureAwait(false);

            if (userRole == null)
            {
                return false;
            }

            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public async Task<List<UserRoleDto>> GetUserRolesByUserIdAsync(string userId)
        {
            var userRoles = await _context.UserRoles
                .Include(ur => ur.User)
                .Include(ur => ur.Role)
                .Where(ur => ur.UserId == userId)
                .ToListAsync()
                .ConfigureAwait(false);

            var userRoleDtos = userRoles.Select(ur => new UserRoleDto
            {
                UserId = ur.UserId,
                RoleId = ur.RoleId,
                User = new UserDto
                {
                    Id = ur.User.Id,
                    UserName = ur.User.UserName,
                    Name = ur.User.Name,
                    SicilNo = ur.User.SicilNo,
                    UserRegistrationDate = ur.User.UserRegistrationDate
                },
                Role = new RoleDto
                {
                    Id = ur.Role.Id,
                    RoleName = ur.Role.RoleName
                }
            }).ToList();

            return userRoleDtos;
        }


    }



}
