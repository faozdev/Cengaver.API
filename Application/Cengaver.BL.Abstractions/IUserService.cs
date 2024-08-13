using System.Threading.Tasks;
using System.Collections.Generic;
using Cengaver.Domain;
using Cengaver.Dto;

namespace Cengaver.BL.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserByIdAsync(string id); // IdentityUser uses string for Id
        Task<UserDto> AddUserAsync(UserDto userDto);
        Task<UserDto> UpdateUserAsync(string id, UserDto userDto);
        Task<bool> DeleteUserAsync(string id);
        Task<UserDto> GetCurrentUserAsync();
        Task<string> GetUserNameByIdAsync(string id);   

    }
}