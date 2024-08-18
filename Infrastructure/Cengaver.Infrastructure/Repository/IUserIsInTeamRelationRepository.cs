using Cengaver.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Infrastructure.Repository
{
    public interface IUserIsInTeamRelationRepository
    {
        Task<List<UserIsInTeamRelation>> GetAllAsync();
        Task<UserIsInTeamRelation> GetByIdAsync(string userId, int teamId);
        Task AddAsync(UserIsInTeamRelation relation);
        Task UpdateAsync(UserIsInTeamRelation relation);
        Task DeleteAsync(UserIsInTeamRelation relation);
        Task<List<UserIsInTeamRelation>> GetByUserIdAsync(string userId);
        Task<List<UserIsInTeamRelation>> GetByTeamIdAsync(int teamId);
    }
}
