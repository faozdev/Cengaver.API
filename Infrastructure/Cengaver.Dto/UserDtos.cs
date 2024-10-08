﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Dto
{
    public class UserDto
    {
        public string Id { get; set; } 
        public string UserName { get; set; }
        public string Name { get; set; } 
        public string SicilNo { get; set; }
        public DateTime UserRegistrationDate { get; set; }
    }

    public class UserCreateDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string SicilNo { get; set; }
        public DateTime UserRegistrationDate { get; set; }
    }

    public class UserUpdateDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string SicilNo { get; set; }
        public DateTime UserRegistrationDate { get; set; }
    }
}
