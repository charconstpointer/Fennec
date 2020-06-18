using System;
using Fennec.Core.Entities.Users;

namespace Fennec.Core.Entities
{
    public class Advertiser : RegisteredUser
    {
        protected Advertiser(string ipAddress, string email, string password, string username) : base(ipAddress, email,
            password, username)
        {
            IsVerified = false;
        }

        public bool IsVerified { get; private set; }
        
        public new static Advertiser Create(string ipAddress, string username, string email, string password)
        {
            ValidateUserData(ipAddress, username, email, password);
            var advertiser = new Advertiser(ipAddress, email, password, username);
            return advertiser;
        }
    }
}