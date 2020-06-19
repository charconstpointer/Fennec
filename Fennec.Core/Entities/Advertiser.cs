using System;
using Fennec.Core.Entities.Users;

namespace Fennec.Core.Entities
{
    public class Advertiser : RegisteredUser
    {
        protected Advertiser(Guid id, string ipAddress, string email, string password, string username) : base(id, ipAddress, email,
            password, username)
        {
            IsVerified = false;
        }

        public bool IsVerified { get; private set; }
        
        public static Advertiser Create(Guid id,string ipAddress, string username, string email, string password)
        {
            ValidateUserData(ipAddress, username, email, password);
            var advertiser = new Advertiser(id, ipAddress, email, password, username);
            return advertiser;
        }
    }
}