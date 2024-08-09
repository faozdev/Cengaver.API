using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Dto
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }

    public class RoleCreateDto
    {
        public string RoleName { get; set; }
    }

    public class RoleUpdateDto
    {
        public string RoleName { get; set; }
    }

}
