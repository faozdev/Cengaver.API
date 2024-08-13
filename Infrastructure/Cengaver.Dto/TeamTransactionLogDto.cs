using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Dto
{
    public class TeamTransactionLogDto
    {
        /// <summary>
        /// Gets or sets the ID of the team transaction log.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the team associated with this transaction.
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// Gets or sets the type of the transaction.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets additional data related to the transaction.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Optional navigation property for related team.
        /// </summary>
       //public TeamDto Team { get; set; }
    }

}
