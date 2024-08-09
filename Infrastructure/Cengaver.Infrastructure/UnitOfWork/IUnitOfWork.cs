using Cengaver.Domain;
using Cengaver.BL.Abstractions;
using Cengaver.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cengaver.Infrastructure.Extentions;

namespace Cengaver.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<Role> Roles { get; }
        IGenericRepository<GuardDuty> GuardDuties { get; }
        IGenericRepository<GuardDutyBreak> GuardDutyBreaks { get; }
        IGenericRepository<UserCommunication> UserCommunications { get; }
        IGenericRepository<CommunicationType> CommunicationTypes { get; }
        IGenericRepository<Team> Teams { get; }
        IGenericRepository<UserIsInTeamRelation> UserIsInTeamRelations { get; }
        IGenericRepository<TeamTransactionLog> TeamTransactionLogs { get; }
        IGenericRepository<GuardDutyNote> GuardDutyNotes { get; }
        IGenericRepository<GuardDutyNoteType> GuardDutyNoteTypes { get; }

        Task<int> SaveChangesAsync();
        int SaveChanges();
    }

}
