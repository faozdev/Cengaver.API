using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Dto
{
    public class PermissionDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string UserPermission { get; set; }
    }


    public class PermissionCreateDto
    {
        public int RoleId { get; set; }
        public string UserPermission { get; set; }
    }

}
