using AutoMapper;
using Cengaver.BL.Abstractions;
using Cengaver.Domain;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cengaver.Dto;
using Cengaver.Persistence;
using Microsoft.Data.SqlClient;

namespace Cengaver.BL
{
    public class UserTeamService : IUserTeamService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper; 

        public UserTeamService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserTeamDto>> GetUserTeamsAsync()
        {
            var userTeamEntities = await _context.UserIsInTeamRelations.ToListAsync().ConfigureAwait(false);
            return _mapper.Map<List<UserTeamDto>>(userTeamEntities);
        }

        public async Task<List<UserTeamDto>> GetUserTeamsByUserIdAsync(string userId)
        {
            var userTeamEntities = await _context.UserIsInTeamRelations
                .Where(ut => ut.UserId == userId)
                .ToListAsync()
                .ConfigureAwait(false);
            return _mapper.Map<List<UserTeamDto>>(userTeamEntities);
        }

        public async Task<UserTeamDto> AddUserToTeamAsync(UserTeamDto userTeamDto)
        {
            // Check if the user and team exist
            var user = await _context.Users.FindAsync(userTeamDto.UserId);
            var team = await _context.Teams.FindAsync(userTeamDto.TeamId);

            if (user == null || team == null)
            {
                throw new ArgumentException("Invalid user or team ID.");
            }

            var existingRelation = await _context.UserIsInTeamRelations
                .FirstOrDefaultAsync(ut => ut.UserId == userTeamDto.UserId && ut.TeamId == userTeamDto.TeamId);

            if (existingRelation != null)
            {
                throw new InvalidOperationException("User is already assigned to this team.");
            }

            var userTeamEntity = _mapper.Map<UserIsInTeamRelation>(userTeamDto);
            _context.UserIsInTeamRelations.Add(userTeamEntity);

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2627)
            {
                throw new InvalidOperationException("A primary key constraint was violated. Ensure that there are no duplicate entries.", ex);
            }

            return _mapper.Map<UserTeamDto>(userTeamEntity);
        }


        public async Task<UserTeamDto> UpdateUserTeamAsync(string userId, int teamId, UserTeamDto userTeamDto)
        {
            var existingEntity = await _context.UserIsInTeamRelations
                .FirstOrDefaultAsync(ut => ut.UserId == userId && ut.TeamId == teamId)
                .ConfigureAwait(false);
            if (existingEntity == null)
            {
                return null; 
            }

            existingEntity.CreatedDate = userTeamDto.CreatedDate;

            _context.UserIsInTeamRelations.Update(existingEntity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return _mapper.Map<UserTeamDto>(existingEntity);
        }

        public async Task<bool> DeleteUserFromTeamAsync(string userId, int teamId)
        {
            var existingEntity = await _context.UserIsInTeamRelations
                .FirstOrDefaultAsync(ut => ut.UserId == userId && ut.TeamId == teamId)
                .ConfigureAwait(false);
            if (existingEntity == null)
            {
                return false;
            }

            _context.UserIsInTeamRelations.Remove(existingEntity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<List<UserTeamDto>> GetUsersByTeamIdAsync(int teamId)
        {
            var userTeamEntities = await _context.UserIsInTeamRelations
                .Where(ut => ut.TeamId == teamId)
                .ToListAsync()
                .ConfigureAwait(false);

            return _mapper.Map<List<UserTeamDto>>(userTeamEntities);
        }


    }

}
