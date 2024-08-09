using Cengaver.Domain;
using Cengaver.BL.Abstractions;
using Cengaver.Infrastructure.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL
{
    public class UserCommunicationService : IUserCommunicationService
    {
        private readonly IGenericRepository<UserCommunication> _userCommunicationRepository;

        public UserCommunicationService(IGenericRepository<UserCommunication> userCommunicationRepository)
        {
            _userCommunicationRepository = userCommunicationRepository;
        }

        public async Task<IEnumerable<UserCommunication>> GetAllAsync()
        {
            return await _userCommunicationRepository.GetAllAsync();
        }

        public async Task<UserCommunication> GetByIdAsync(int userId, int communicationTypeId)
        {
            return await _userCommunicationRepository.GetByIdAsync(userId, communicationTypeId);
        }

        public async Task<UserCommunication> AddAsync(UserCommunication userCommunication)
        {
            await _userCommunicationRepository.AddAsync(userCommunication);
            return userCommunication; 
        }

        public async Task<UserCommunication> UpdateAsync(UserCommunication userCommunication)
        {
            await _userCommunicationRepository.UpdateAsync(userCommunication);
            return userCommunication;
        }

        public async Task<bool> DeleteAsync(int userId, int communicationTypeId)
        {
            var userCommunication = await _userCommunicationRepository.GetByIdAsync(userId, communicationTypeId);
            if (userCommunication == null)
            {
                return false; 
            }

            await _userCommunicationRepository.DeleteAsync(userCommunication);
            return true; 
        }
    }

}
