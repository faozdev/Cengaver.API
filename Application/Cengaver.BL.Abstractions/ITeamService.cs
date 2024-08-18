using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cengaver.Dto;

namespace Cengaver.BL.Abstractions
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamDto>> GetTeamsAsync();
        Task<TeamDto> GetTeamByIdAsync(int id);
        Task<TeamDto> AddTeamAsync(TeamDto teamDto);
        Task<TeamDto> UpdateTeamAsync(int id, TeamDto teamDto);
        Task<bool> DeleteTeamAsync(int id);
    }
}
