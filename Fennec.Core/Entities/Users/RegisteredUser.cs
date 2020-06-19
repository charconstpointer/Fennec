using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Fennec.Core.Entities.Users
{
    public class RegisteredUser : Visitor, IEntity
    {
        protected RegisteredUser(Guid id, string ipAddress, string email, string password, string username,
            ISet<Comment> comments = null) : base(ipAddress)
        {
            Email = email;
            Password = password;
            Username = username;
            Comments = comments ?? new HashSet<Comment>();
            IsBanned = false;
            Id = id;
        }

        public Guid Id { get; }
        public string Email { get; private set; }
        public bool IsBanned { get; private set; }
        public string Password { get; private set; }
        public string Username { get; }
        protected readonly ISet<Comment> Comments;
        public IReadOnlyCollection<Comment> UserComments => Comments.ToImmutableList();

        public static RegisteredUser Create(Guid id, string ipAddress, string username, string email, string password,
            ISet<Comment> comments = null)
        {
            ValidateUserData(ipAddress, username, email, password);
            var registeredUser = new RegisteredUser(id, ipAddress, username, email, password, comments);
            return registeredUser;
        }

        
        
        protected static void ValidateUserData(string ipAddress, string username, string email, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException($"{nameof(username)} is null or empty");
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException($"{nameof(email)} is null or empty");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException($"{nameof(password)} is null or empty");
            }

            if (string.IsNullOrEmpty(ipAddress))
            {
                throw new ArgumentException($"{nameof(ipAddress)} is null or empty");
            }
        }

        public void AddComment(Comment comment)
        {
            if (comment is null)
            {
                throw new ApplicationException("Comment cannot be null");
            }

            if (Comments.Contains(comment))
            {
                return;
            }

            Comments.Add(comment);
            comment.Author = this;
        }
    }
}