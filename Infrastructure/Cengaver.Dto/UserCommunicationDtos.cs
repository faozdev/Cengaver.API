using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Dto
{
    public class UserCommunicationDto
    {
        public string UserId { get; set; }
        public int CommunicationTypeId { get; set; }
        public string CommunicationString { get; set; }
    }

    public class UserCommunicationCreateDto
    {
        public string UserId { get; set; }
        public int CommunicationTypeId { get; set; }
        public string CommunicationString { get; set; }
    }

}
