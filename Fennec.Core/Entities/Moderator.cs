using System;

namespace Fennec.Core.Entities
{
    public class Moderator : RegisteredUser
    {
        protected Moderator(string ipAddress, string email, string password, string username) : base(ipAddress, email,
            password, username)
        {
            
        }

        public static Moderator Create(Category category, string ipAddress, string username, string email, string password)
        {
            ValidateUserData(ipAddress, username, email, password);
            if (category is null)
            {
                throw new ArgumentException($"{nameof(Category)} cannot be null");
            }
            var moderator = new Moderator(ipAddress, email, password, username);
            return moderator;
        }
    }
}