using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Dto
{
    public class UserIsInTeamRelationDto
    {
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class UserIsInTeamRelationCreateDto
    {
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
