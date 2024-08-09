namespace Cengaver.Domain
{

    public class GuardDutyBreak
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TypeId { get; set; }
        public DateTime DateOfClaim { get; set; }

        public User User { get; set; }
        public GuardDutyBreakType GuardDutyBreakType { get; set; }
    }
}
