namespace Cengaver.Domain
{
    public class GuardDuty
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string WardenUserId { get; set; }
        public DateTime DateOfAssignment { get; set; }
        public string GuardAssignedByUser { get; set; }
        public User WardenUser { get; set; }
        public ICollection<GuardDutyNote> GuardDutyNotes { get; set; }
    }
}
