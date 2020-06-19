using System;
using Fennec.Core.ValueObjects;

namespace Fennec.Core.Entities.Users
{
    public class Creator : RegisteredUser
    {
        protected Creator(Guid id, string ipAddress, string email, string password, string username) : base(id, ipAddress, email,
            password, username)
        {
        }

        public Money Money { get; private set; }
    }
}