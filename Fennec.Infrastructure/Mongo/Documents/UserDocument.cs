using System;
using System.Collections.Generic;

namespace Fennec.Infrastructure.Mongo.Documents
{
    public class UserDocument
    {
        public Guid Id { get; set; }
        public string Email { get;  set; }
        public bool IsBanned { get;  set; }
        public string Password { get;  set; }
        public string Username { get; set; }
        public IEnumerable<CommentDocument> Comments { get; set; }
    }
}