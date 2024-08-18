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
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Cengaver.BL
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return users.Select(user => new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
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
                Name = user.Name,
                SicilNo = user.SicilNo,
                UserRegistrationDate = user.UserRegistrationDate
            };
        }

        public async Task<string> GetUserNameByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user?.Name;
        }

        public async Task<UserDto> AddUserAsync(UserDto userDto)
        {
            var user = new User
            {
                UserName = userDto.UserName,
                SicilNo = userDto.SicilNo,
                Name = userDto.Name,
                UserRegistrationDate = userDto.UserRegistrationDate
            };

            var result = await _userManager.CreateAsync(user, GenerateSecurePassword());
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

            throw new Exception("User creation failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        public async Task<UserDto> UpdateUserAsync(string id, UserDto userDto)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return null;

            user.UserName = userDto.UserName;
            user.SicilNo = userDto.SicilNo;
            user.Name = userDto.Name;
            user.UserRegistrationDate = userDto.UserRegistrationDate;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Name = user.Name,
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

        public async Task<UserDto> GetCurrentUserAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return null; // Or handle as appropriate
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                SicilNo = user.SicilNo,
                UserRegistrationDate = user.UserRegistrationDate
            };
        }

        private string GenerateSecurePassword()
        {
            return "DefaultPassword123!";
        }

        public async Task<IEnumerable<string>> GetNamesAsync()
        {
            var users = await _userManager.Users
                .Select(u => u.Name)  
                .ToListAsync();
            return users;
        }

        public async Task<string> GetUserIdByNameAsync(string name)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.Name == name);

            return user?.Id;
        }

    }
}
