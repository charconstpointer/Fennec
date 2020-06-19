using System;

namespace Fennec.Application.DTO
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public DateTime DateOfComment { get; set; }
    }
}