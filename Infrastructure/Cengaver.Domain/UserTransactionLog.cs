﻿namespace Cengaver.Domain
{

    public class UserTransactionLog
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
    }
}
