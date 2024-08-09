using Cengaver.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{
    public interface IUserCommunicationService
    {
        Task<IEnumerable<UserCommunication>> GetAllAsync();
        Task<UserCommunication> GetByIdAsync(int userId, int communicationTypeId);
        Task<UserCommunication> AddAsync(UserCommunication userCommunication);
        Task<UserCommunication> UpdateAsync(UserCommunication userCommunication);
        Task<bool> DeleteAsync(int userId, int communicationTypeId);
    }
}
