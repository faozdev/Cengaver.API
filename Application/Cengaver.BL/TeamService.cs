using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cengaver.Dto;
using Cengaver.Domain;
using Cengaver.Persistence;
using Cengaver.BL.Abstractions;

namespace Cengaver.BL
{
    public class TeamService : ITeamService
    {
        private readonly DataContext _context;

        public TeamService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeamDto>> GetTeamsAsync()
        {
            return await _context.Teams
                .Select(t => new TeamDto
                {
                    Id = t.Id,
                    TeamName = t.TeamName,
                    TeamLogo = t.TeamLogo,
                    CreatedDate = t.CreatedDate
                })
                .ToListAsync();
        }

        public async Task<TeamDto> GetTeamByIdAsync(int id)
        {
            var team = await _context.Teams
                .Where(t => t.Id == id)
                .Select(t => new TeamDto
                {
                    Id = t.Id,
                    TeamName = t.TeamName,
                    TeamLogo = t.TeamLogo,
                    CreatedDate = t.CreatedDate
                })
                .FirstOrDefaultAsync();

            return team;
        }

        public async Task<TeamDto> AddTeamAsync(TeamDto teamDto)
        {
            var team = new Team
            {
                TeamName = teamDto.TeamName,
                TeamLogo = teamDto.TeamLogo,
                CreatedDate = teamDto.CreatedDate
            };

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return teamDto;
        }

        public async Task<TeamDto> UpdateTeamAsync(int id, TeamDto teamDto)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return null;

            team.TeamName = teamDto.TeamName;
            team.TeamLogo = teamDto.TeamLogo;
            team.CreatedDate = teamDto.CreatedDate;

            _context.Teams.Update(team);
            await _context.SaveChangesAsync();

            return teamDto;
        }

        public async Task<bool> DeleteTeamAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return false;

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
