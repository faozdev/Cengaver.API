using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Dto
{
    public class CommunicationTypeDto
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }

    public class CommunicationTypeCreateDto
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }

    public class CommunicationTypeUpdateDto
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }

}
