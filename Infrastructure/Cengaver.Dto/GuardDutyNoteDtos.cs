using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Dto
{
    public class GuardDutyNoteDto
    {
        public int Id { get; set; }
        public int GuardDutyId { get; set; }
        public int NoteTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class GuardDutyNoteCreateDto
    {
        public int GuardDutyId { get; set; }
        public int NoteTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
    }

}
