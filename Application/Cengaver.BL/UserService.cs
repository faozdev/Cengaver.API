using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cengaver.Domain;
using Cengaver.Persistence;
using Cengaver.BL.Abstractions;
using Cengaver.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Cengaver.BL
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return users.Select(user => new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                SicilNo = user.SicilNo,
                UserRegistrationDate = user.UserRegistrationDate
            });
        }

        public async Task<UserDto> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                SicilNo = user.SicilNo,
                UserRegistrationDate = user.UserRegistrationDate
            };
        }

        public async Task<UserDto> AddUserAsync(UserDto userDto)
        {
            var user = new User
            {
                UserName = userDto.UserName,
                SicilNo = userDto.SicilNo,
                UserRegistrationDate = userDto.UserRegistrationDate
            };

            var result = await _userManager.CreateAsync(user, "DefaultPassword123!"); // Handle passwords securely in production
            if (result.Succeeded)
            {
                // Return the created user DTO with updated Id
                return new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    SicilNo = user.SicilNo,
                    UserRegistrationDate = user.UserRegistrationDate
                };
            }

            throw new Exception("User creation failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        public async Task<UserDto> UpdateUserAsync(string id, UserDto userDto)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return null;

            user.UserName = userDto.UserName;
            user.SicilNo = userDto.SicilNo;
            user.UserRegistrationDate = userDto.UserRegistrationDate;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    SicilNo = user.SicilNo,
                    UserRegistrationDate = user.UserRegistrationDate
                };
            }

            throw new Exception("User update failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return false;

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }
    }
}
