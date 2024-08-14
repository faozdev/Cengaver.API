using Cengaver.BL.Abstractions;
using Cengaver.Domain;
using Cengaver.Dto;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cengaver.BL.Abstractions;
using Cengaver.Infrastructure.Repository;
using AutoMapper;
using Cengaver.Persistence;

namespace Cengaver.BL
{
    public class UserIsInTeamRelationService : IUserIsInTeamRelationService
    {
        private readonly DataContext _context;

        public UserIsInTeamRelationService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<UserIsInTeamRelationDto>> GetUserTeamRelationsAsync()
        {
            return await _context.UserIsInTeamRelations
                .Select(utr => new UserIsInTeamRelationDto
                {
                    UserId = utr.UserId,
                    TeamId = utr.TeamId,
                    CreatedDate = utr.CreatedDate
                })
                .ToListAsync();
        }

        public async Task<UserIsInTeamRelationDto> GetUserTeamRelationByIdAsync(string userId, int teamId)
        {
            var relation = await _context.UserIsInTeamRelations
                .Where(utr => utr.UserId == userId && utr.TeamId == teamId)
                .Select(utr => new UserIsInTeamRelationDto
                {
                    UserId = utr.UserId,
                    TeamId = utr.TeamId,
                    CreatedDate = utr.CreatedDate
                })
                .FirstOrDefaultAsync();

            return relation;
        }

        public async Task<UserIsInTeamRelationDto> AddUserTeamRelationAsync(UserIsInTeamRelationCreateDto createDto)
        {
            var relation = new UserIsInTeamRelation
            {
                UserId = createDto.UserId,
                TeamId = createDto.TeamId,
                CreatedDate = DateTime.UtcNow
            };

            _context.UserIsInTeamRelations.Add(relation);
            await _context.SaveChangesAsync();

            return new UserIsInTeamRelationDto
            {
                UserId = relation.UserId,
                TeamId = relation.TeamId,
                CreatedDate = relation.CreatedDate
            };
        }

        public async Task<UserIsInTeamRelationDto> UpdateUserTeamRelationAsync(string userId, int teamId, UserIsInTeamRelationUpdateDto updateDto)
        {
            var relation = await _context.UserIsInTeamRelations
                .Where(utr => utr.UserId == userId && utr.TeamId == teamId)
                .FirstOrDefaultAsync();

            if (relation == null)
                return null;

            // Güncellemeleri uygula
            // Örneğin, eğer güncelleme yapılacak alanlar varsa:
            // relation.SomeField = updateDto.SomeField;

            await _context.SaveChangesAsync();

            return new UserIsInTeamRelationDto
            {
                UserId = relation.UserId,
                TeamId = relation.TeamId,
                CreatedDate = relation.CreatedDate
            };
        }

        public async Task<bool> DeleteUserTeamRelationAsync(string userId, int teamId)
        {
            var relation = await _context.UserIsInTeamRelations
                .Where(utr => utr.UserId == userId && utr.TeamId == teamId)
                .FirstOrDefaultAsync();

            if (relation == null)
                return false;

            _context.UserIsInTeamRelations.Remove(relation);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<int>> GetTeamIdsByUserIdAsync(string userId)
        {
            return await _context.UserIsInTeamRelations
                .Where(utr => utr.UserId == userId)
                .Select(utr => utr.TeamId)
                .ToListAsync();
        }

        public async Task<List<UserIsInTeamRelationDto>> GetUserTeamRelationsByUserIdAsync(string userId)
        {
            return await _context.UserIsInTeamRelations
                .Where(utr => utr.UserId == userId)
                .Select(utr => new UserIsInTeamRelationDto
                {
                    UserId = utr.UserId,
                    TeamId = utr.TeamId,
                    CreatedDate = utr.CreatedDate
                })
                .ToListAsync();
        }
    }



}
