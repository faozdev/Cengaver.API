using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Dto
{
    public class GuardDutyDto
    {
        public int  Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string WardenUserId { get; set; }
        public DateTime DateOfAssignment { get; set; }
        public string GuardAssignedByUser { get; set; }
    }

    public class GuardDutyCreateDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string WardenUserId { get; set; }
        public DateTime DateOfAssignment { get; set; }
        public string GuardAssignedByUser { get; set; }
    }

}
