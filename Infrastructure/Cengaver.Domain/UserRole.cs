﻿using System.Data;

namespace Cengaver.Domain
{
    public class UserRole
    {
        public string UserId { get; set; } 
        public int RoleId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}

