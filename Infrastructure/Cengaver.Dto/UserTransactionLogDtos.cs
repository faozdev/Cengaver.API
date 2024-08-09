﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Dto
{
    public class UserTransactionLogDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class UserTransactionLogCreateDto
    {
        public string UserId { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
