using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Dto
{
    public class UserRoleDto
    {
        public string UserId { get; set; }
        public int RoleId { get; set; }
        public UserDto User { get; set; } // Assuming UserDto is defined
        public RoleDto Role { get; set; } // Assuming RoleDto is defined
    }

    public class UserRoleCreateDto
    {
        public string UserId { get; set; }
        public int RoleId { get; set; }
    }

    public class UserRoleUpdateDto
    {
        public string UserId { get; set; } // Add UserId property
        public int RoleId { get; set; }     // Ensure RoleId is also included if needed
    }

}
