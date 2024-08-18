using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Dto
{
    public class TeamTransactionLogDto
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
    }

}
