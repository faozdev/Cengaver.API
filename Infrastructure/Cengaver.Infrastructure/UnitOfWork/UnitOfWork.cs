using Cengaver.Domain;
using Cengaver.Infrastructure.Extentions;
using Cengaver.Infrastructure.Repository;
using Cengaver.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IGenericRepository<User> Users => GetRepository<User>();
        public IGenericRepository<Role> Roles => GetRepository<Role>();
        public IGenericRepository<GuardDuty> GuardDuties => GetRepository<GuardDuty>();
        public IGenericRepository<GuardDutyBreak> GuardDutyBreaks => GetRepository<GuardDutyBreak>();
        public IGenericRepository<UserCommunication> UserCommunications => GetRepository<UserCommunication>();
        public IGenericRepository<CommunicationType> CommunicationTypes => GetRepository<CommunicationType>();
        public IGenericRepository<Team> Teams => GetRepository<Team>();
        public IGenericRepository<UserIsInTeamRelation> UserIsInTeamRelations => GetRepository<UserIsInTeamRelation>();
        public IGenericRepository<TeamTransactionLog> TeamTransactionLogs => GetRepository<TeamTransactionLog>();
        public IGenericRepository<GuardDutyNote> GuardDutyNotes => GetRepository<GuardDutyNote>();
        public IGenericRepository<GuardDutyNoteType> GuardDutyNoteTypes => GetRepository<GuardDutyNoteType>();

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repositoryType = typeof(GenericRepository<T>);
                var repositoryInstance = Activator.CreateInstance(repositoryType, _context);
                _repositories.Add(typeof(T), repositoryInstance);
            }
            return (IGenericRepository<T>)_repositories[typeof(T)];
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
