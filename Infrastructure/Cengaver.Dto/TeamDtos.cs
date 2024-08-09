using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Dto
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string TeamLogo { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class TeamCreateDto
    {
        public string TeamName { get; set; }
        public string TeamLogo { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class TeamUpdateDto
    {
        public string TeamName { get; set; }
        public string TeamLogo { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }

}
