using System;
using System.Collections.Generic;
using Fennec.Core.Entities;

namespace Fennec.Application.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool IsBanned { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public  IEnumerable<CommentDto> Comments { get; set; }
    }
}