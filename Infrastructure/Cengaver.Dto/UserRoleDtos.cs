﻿using System;
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
    }

    public class UserRoleCreateDto
    {
        public string UserId { get; set; }
        public int RoleId { get; set; }
    }

}
