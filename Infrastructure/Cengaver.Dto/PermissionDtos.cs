using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Dto
{
    public class PermissionDto
    {
        /// <summary>
        /// Gets or sets the ID of the permission.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the role associated with the permission.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the permission string.
        /// </summary>
        public string UserPermission { get; set; }
    }


    public class PermissionCreateDto
    {
        public int RoleId { get; set; }
        public string UserPermission { get; set; }
    }

}
