using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Dto
{
    public class GuardDutyBreakTypeDto
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }

    public class GuardDutyBreakTypeCreateDto
    {
        public string TypeName { get; set; }
    }

}
