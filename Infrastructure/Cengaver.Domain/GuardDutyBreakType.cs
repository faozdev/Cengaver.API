namespace Cengaver.Domain
{
    public class GuardDutyBreakType
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public ICollection<GuardDutyBreak> GuardDutyBreaks { get; set; }
    }
}
