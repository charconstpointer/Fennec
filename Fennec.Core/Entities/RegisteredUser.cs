using System;

namespace Fennec.Core.Entities
{
    public class RegisteredUser : Visitor, IEntity
    {
        protected RegisteredUser(string ipAddress, string email, string password, string username) : base(ipAddress)
        {
            Email = email;
            Password = password;
            Username = username;
            IsBanned = false;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public string Email { get; private set; }
        public bool IsBanned { get; private set; }
        public string Password { get; private set; }
        public string Username { get; }


        public static RegisteredUser Create(string ipAddress, string username, string email, string password)
        {
            ValidateUserData(ipAddress, username, email, password);
            var registeredUser = new RegisteredUser(ipAddress, username, email, password);
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
    }
}