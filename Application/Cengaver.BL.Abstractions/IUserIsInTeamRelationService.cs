using Cengaver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{
    public interface IUserIsInTeamRelationService
    {
        Task<List<UserIsInTeamRelationDto>> GetUserTeamRelationsAsync();
        Task<UserIsInTeamRelationDto> GetUserTeamRelationByIdAsync(string userId, int teamId);
        Task<UserIsInTeamRelationDto> AddUserTeamRelationAsync(UserIsInTeamRelationCreateDto createDto);
        Task<UserIsInTeamRelationDto> UpdateUserTeamRelationAsync(string userId, int teamId, UserIsInTeamRelationUpdateDto updateDto);
        Task<bool> DeleteUserTeamRelationAsync(string userId, int teamId);
        Task<List<int>> GetTeamIdsByUserIdAsync(string userId);
        Task<List<UserIsInTeamRelationDto>> GetUserTeamRelationsByUserIdAsync(string userId); 
    }
}
