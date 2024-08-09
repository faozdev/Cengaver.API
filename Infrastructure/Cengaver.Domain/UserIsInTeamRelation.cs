﻿namespace Cengaver.Domain
{
    public class UserIsInTeamRelation
    {
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public DateTime CreatedDate { get; set; }

        public User User { get; set; }
        public Team Team { get; set; }
    }
}
