using System;
using Fennec.Core.Entities.Content;
using Fennec.Core.Entities.Users;

namespace Fennec.Core.Entities
{
    public class Comment : IEntity
    {
        private RegisteredUser _author;
        public Guid Id { get; }
        public string Body { get; private set; }
        public DateTime DateOfComment { get; }

        public RegisteredUser Author
        {
            get => _author;
            set
            {
                if (value is null)
                {
                    throw new ApplicationException("Author cannot be null");
                }

                if (value == Author)
                {
                    return;
                }
                _author = value;
                _author.AddComment(this);
            }
        }

        public IContent Content { get; set; }

        private Comment(Guid id, string body, RegisteredUser author)
        {
            Id = id;
            Body = body;
            Author = author;
            DateOfComment = DateTime.UtcNow;
        }

        public static Comment Create(Guid id, string body, RegisteredUser user)
        {
            if (user is null)
            {
                throw new ApplicationException("User cannot be null");
            }
            var comment = new Comment(id, body, user);
            return comment;
        }
    }
}