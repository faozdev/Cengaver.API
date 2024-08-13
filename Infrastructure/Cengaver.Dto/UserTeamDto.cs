using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Dto
{
    public class UserTeamDto
    {
        /// <summary>
        /// The ID of the user.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The ID of the team.
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// The date when the user was added to the team.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Details about the user.
        /// </summary>
        public UserDto User { get; set; }

        /// <summary>
        /// Details about the team.
        /// </summary>
        public TeamDto Team { get; set; }
    }

}
