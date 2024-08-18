using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Dto
{
    public class UserTeamDto
    {
        public string UserId { get; set; }
        public int TeamId { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserDto User { get; set; }
        public TeamDto Team { get; set; }
    }

}
