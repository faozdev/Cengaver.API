using Cengaver.Domain;
using Cengaver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{
    public interface IUserCommunicationService
    {
        Task<List<UserCommunicationDto>> GetUserCommunicationsAsync();
        Task<UserCommunicationDto> GetUserCommunicationByIdAsync(string userId, int communicationTypeId);
        Task<UserCommunicationDto> AddUserCommunicationAsync(UserCommunicationDto userCommunicationDto);
        Task<UserCommunicationDto> UpdateUserCommunicationAsync(string userId, int communicationTypeId, UserCommunicationDto userCommunicationDto);
        Task<bool> DeleteUserCommunicationAsync(string userId, int communicationTypeId);
        Task<List<UserCommunicationDto>> GetUserCommunicationsByUserIdAsync(string userId);
    }
}
