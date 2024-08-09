using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Dto
{
    public class GuardDutyNoteTypeDto
    {
        public int NoteTypeId { get; set; }
        public string NoteTypeName { get; set; }
    }

    public class GuardDutyNoteTypeCreateDto
    {
        public string NoteTypeName { get; set; }
    }

}
