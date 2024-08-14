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
    public class UserCommunicationRepository : IUserCommunicationRepository
    {
        private readonly DataContext _context;

        public UserCommunicationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<UserCommunication>> GetAllAsync()
        {
            return await _context.UserCommunications
                .Include(uc => uc.User)
                .Include(uc => uc.CommunicationType)
                .ToListAsync();
        }

        public async Task<UserCommunication> GetByIdAsync(string userId, int communicationTypeId)
        {
            return await _context.UserCommunications
                .Include(uc => uc.User)
                .Include(uc => uc.CommunicationType)
                .FirstOrDefaultAsync(uc => uc.UserId == userId && uc.CommunicationTypeId == communicationTypeId);
        }

        public async Task<UserCommunication> AddAsync(UserCommunication userCommunication)
        {
            _context.UserCommunications.Add(userCommunication);
            await _context.SaveChangesAsync();
            return userCommunication;
        }

        public async Task<UserCommunication> UpdateAsync(UserCommunication userCommunication)
        {
            var existingUserCommunication = await _context.UserCommunications
                .FirstOrDefaultAsync(uc => uc.UserId == userCommunication.UserId && uc.CommunicationTypeId == userCommunication.CommunicationTypeId);

            if (existingUserCommunication == null)
            {
                return null; // Or throw an exception if you prefer
            }

            existingUserCommunication.CommunicationString = userCommunication.CommunicationString;

            _context.UserCommunications.Update(existingUserCommunication);
            await _context.SaveChangesAsync();
            return existingUserCommunication;
        }

        public async Task DeleteAsync(UserCommunication userCommunication)
        {
            var existingUserCommunication = await _context.UserCommunications
                .FirstOrDefaultAsync(uc => uc.UserId == userCommunication.UserId && uc.CommunicationTypeId == userCommunication.CommunicationTypeId);

            if (existingUserCommunication != null)
            {
                _context.UserCommunications.Remove(existingUserCommunication);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<UserCommunication>> GetByUserIdAsync(string userId)
        {
            return await _context.UserCommunications
                .Where(uc => uc.UserId == userId)
                .ToListAsync();
        }
    }

}
