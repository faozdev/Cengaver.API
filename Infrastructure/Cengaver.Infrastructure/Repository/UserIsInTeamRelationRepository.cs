using Cengaver.Domain;
using Cengaver.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cengaver.Infrastructure.Repository
{
    public class UserIsInTeamRelationRepository : IUserIsInTeamRelationRepository
    {
        private readonly DataContext _context;

        public UserIsInTeamRelationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<UserIsInTeamRelation>> GetAllAsync()
        {
            return await _context.UserIsInTeamRelations.ToListAsync();
        }

        public async Task<UserIsInTeamRelation> GetByIdAsync(string userId, int teamId)
        {
            return await _context.UserIsInTeamRelations
                .FirstOrDefaultAsync(r => r.UserId == userId && r.TeamId == teamId);
        }

        public async Task AddAsync(UserIsInTeamRelation relation)
        {
            await _context.UserIsInTeamRelations.AddAsync(relation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserIsInTeamRelation relation)
        {
            _context.UserIsInTeamRelations.Update(relation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserIsInTeamRelation relation)
        {
            _context.UserIsInTeamRelations.Remove(relation);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserIsInTeamRelation>> GetByUserIdAsync(string userId)
        {
            return await _context.UserIsInTeamRelations
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<UserIsInTeamRelation>> GetByTeamIdAsync(int teamId)
        {
            return await _context.UserIsInTeamRelations
                .Where(r => r.TeamId == teamId)
                .ToListAsync();
        }
    }


}
