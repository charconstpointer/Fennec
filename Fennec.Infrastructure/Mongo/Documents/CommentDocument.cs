using System;

namespace Fennec.Infrastructure.Mongo.Documents
{
    public class CommentDocument
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public DateTime DateOfComment { get; set; }
    }
}