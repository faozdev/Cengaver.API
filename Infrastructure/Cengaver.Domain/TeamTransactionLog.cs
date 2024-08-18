namespace Cengaver.Domain
{
    public class TeamTransactionLog
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public Team Team { get; set; }
    }
}
