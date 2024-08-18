namespace Cengaver.Domain
{
    public class CommunicationType
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public ICollection<UserCommunication> UserCommunications { get; set; }
    }
}
