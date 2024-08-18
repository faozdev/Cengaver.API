namespace Cengaver.Domain
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string TeamLogo { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<TeamTransactionLog> TeamTransactionLogs { get; set; }
        public ICollection<UserIsInTeamRelation> UserIsInTeamRelations { get; set; }
    }
}
