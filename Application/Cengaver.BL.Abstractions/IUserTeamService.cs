using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cengaver.Dto;

namespace Cengaver.BL.Abstractions
{
    public interface IUserTeamService
    {
        Task<List<UserTeamDto>> GetUserTeamsAsync();
        Task<List<UserTeamDto>> GetUserTeamsByUserIdAsync(string userId);
        Task<UserTeamDto> AddUserToTeamAsync(UserTeamDto userTeamDto);
        Task<UserTeamDto> UpdateUserTeamAsync(string userId, int teamId, UserTeamDto userTeamDto);
        Task<bool> DeleteUserFromTeamAsync(string userId, int teamId);
        Task<List<UserTeamDto>> GetUsersByTeamIdAsync(int teamId);
    }
}
