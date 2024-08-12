using Microsoft.AspNetCore.Identity;

namespace Cengaver.Domain
{
    public class User : IdentityUser
    {
        
        public string SicilNo { get; set; }
        public DateTime UserRegistrationDate { get; set; }
        public string Name { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserIsInTeamRelation> UserIsInTeamRelations { get; set; }
        public ICollection<GuardDuty> GuardDuties { get; set; }
        public ICollection<GuardDutyBreak> GuardDutyBreaks { get; set; }
        public ICollection<UserTransactionLog> UserTransactionLogs { get; set; }
        public ICollection<UserCommunication> UserCommunications { get; set; }
    }
}
