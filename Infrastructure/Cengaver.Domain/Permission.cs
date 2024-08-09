using System.Data;

namespace Cengaver.Domain
{
    public class Permission
    {
        public int RoleId { get; set; }
        public string UserPermission { get; set; }

        public Role Role { get; set; }
    }
}
