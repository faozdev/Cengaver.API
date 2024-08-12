using Cengaver.Domain;
using Cengaver.BL.Abstractions;
using Cengaver.Infrastructure.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cengaver.Dto;
using Cengaver.Infrastructure.Repository;

namespace Cengaver.BL
{
    public class UserCommunicationService : IUserCommunicationService
    {
        private readonly IUserCommunicationRepository _userCommunicationRepository;

        public UserCommunicationService(IUserCommunicationRepository userCommunicationRepository)
        {
            _userCommunicationRepository = userCommunicationRepository;
        }

        public async Task<List<UserCommunicationDto>> GetUserCommunicationsAsync()
        {
            var userCommunications = await _userCommunicationRepository.GetAllAsync().ConfigureAwait(false);
            return userCommunications.Select(uc => new UserCommunicationDto
            {
                UserId = uc.UserId,
                CommunicationTypeId = uc.CommunicationTypeId,
                CommunicationString = uc.CommunicationString
            }).ToList();
        }

        public async Task<UserCommunicationDto> GetUserCommunicationByIdAsync(string userId, int communicationTypeId)
        {
            var userCommunication = await _userCommunicationRepository.GetByIdAsync(userId, communicationTypeId).ConfigureAwait(false);
            if (userCommunication == null)
                return null;

            return new UserCommunicationDto
            {
                UserId = userCommunication.UserId,
                CommunicationTypeId = userCommunication.CommunicationTypeId,
                CommunicationString = userCommunication.CommunicationString
            };
        }

        public async Task<UserCommunicationDto> AddUserCommunicationAsync(UserCommunicationDto userCommunicationDto)
        {
            var userCommunication = new UserCommunication
            {
                UserId = userCommunicationDto.UserId,
                CommunicationTypeId = userCommunicationDto.CommunicationTypeId,
                CommunicationString = userCommunicationDto.CommunicationString
            };

            var addedUserCommunication = await _userCommunicationRepository.AddAsync(userCommunication).ConfigureAwait(false);

            return new UserCommunicationDto
            {
                UserId = addedUserCommunication.UserId,
                CommunicationTypeId = addedUserCommunication.CommunicationTypeId,
                CommunicationString = addedUserCommunication.CommunicationString
            };
        }

        public async Task<UserCommunicationDto> UpdateUserCommunicationAsync(string userId, int communicationTypeId, UserCommunicationDto userCommunicationDto)
        {
            var userCommunication = await _userCommunicationRepository.GetByIdAsync(userId, communicationTypeId).ConfigureAwait(false);
            if (userCommunication == null)
                return null;

            userCommunication.CommunicationString = userCommunicationDto.CommunicationString;

            var updatedUserCommunication = await _userCommunicationRepository.UpdateAsync(userCommunication).ConfigureAwait(false);

            return new UserCommunicationDto
            {
                UserId = updatedUserCommunication.UserId,
                CommunicationTypeId = updatedUserCommunication.CommunicationTypeId,
                CommunicationString = updatedUserCommunication.CommunicationString
            };
        }

        public async Task<bool> DeleteUserCommunicationAsync(string userId, int communicationTypeId)
        {
            var userCommunication = await _userCommunicationRepository.GetByIdAsync(userId, communicationTypeId).ConfigureAwait(false);
            if (userCommunication == null)
                return false;

            await _userCommunicationRepository.DeleteAsync(userCommunication).ConfigureAwait(false);
            return true;
        }
    }

}
