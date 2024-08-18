namespace Cengaver.Domain
{
    public class GuardDutyNote
    {
        public int Id { get; set; }
        public int GuardDutyId { get; set; }
        public int NoteTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public GuardDuty GuardDuty { get; set; }
        public GuardDutyNoteType NoteType { get; set; }
    }
}
