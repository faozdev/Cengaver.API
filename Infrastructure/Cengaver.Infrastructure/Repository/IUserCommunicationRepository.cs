using Cengaver.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Infrastructure.Repository
{
    public interface IUserCommunicationRepository
    {
        Task<List<UserCommunication>> GetAllAsync();
        Task<UserCommunication> GetByIdAsync(string userId, int communicationTypeId);
        Task<UserCommunication> AddAsync(UserCommunication userCommunication);
        Task<UserCommunication> UpdateAsync(UserCommunication userCommunication);
        Task DeleteAsync(UserCommunication userCommunication);
        Task<List<UserCommunication>> GetByUserIdAsync(string userId);
    }

}
