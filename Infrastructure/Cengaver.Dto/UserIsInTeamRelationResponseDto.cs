using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Dto
{
    public class UserIsInTeamRelationResponseDto
    {
        public List<UserIsInTeamRelationDto> UserIsInTeamRelations { get; set; }
        public string Message { get; set; }

        public UserIsInTeamRelationResponseDto(List<UserIsInTeamRelationDto> userIsInTeamRelations, string message = "Success")
        {
            UserIsInTeamRelations = userIsInTeamRelations;
            Message = message;
        }
    }

}
