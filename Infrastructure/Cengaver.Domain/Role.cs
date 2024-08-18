using System.Security;

namespace Cengaver.Domain
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<Permission> Permissions { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }     
    }
}
