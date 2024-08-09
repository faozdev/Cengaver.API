namespace Cengaver.Domain
{
    public class UserCommunication
    {
        public int UserId { get; set; }
        public int CommunicationTypeId { get; set; }
        public string CommunicationString { get; set; }

        public User User { get; set; }
        public CommunicationType CommunicationType { get; set; }
    }
}
