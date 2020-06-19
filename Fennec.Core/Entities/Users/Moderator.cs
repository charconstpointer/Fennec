using System;

namespace Fennec.Core.Entities.Users
{
    public class Moderator : RegisteredUser
    {
        protected Moderator(Guid id, string ipAddress, string email, string password, string username,
            Category category) : base(id, ipAddress, email,
            password, username)
        {
            Category = category;
        }

        public Category Category { get; private set; }

        public static Moderator Create(Guid id, string ipAddress, string username, string email, string password,
            Category category)
        {
            ValidateUserData(ipAddress, username, email, password);
            if (category is null)
            {
                throw new ArgumentException($"{nameof(Category)} cannot be null");
            }

            var moderator = new Moderator(id, ipAddress, email, password, username, category);
            return moderator;
        }
    }
}