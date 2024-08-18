namespace Cengaver.Domain
{

    public class GuardDutyNoteType
    {
        public int NoteTypeId { get; set; }
        public string NoteTypeName { get; set; }
        public ICollection<GuardDutyNote> GuardDutyNotes { get; set; }
    }
}
