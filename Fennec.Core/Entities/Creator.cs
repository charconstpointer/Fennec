using Fennec.Core.Entities.Users;
using Fennec.Core.ValueObjects;

namespace Fennec.Core.Entities
{
    public class Creator : RegisteredUser
    {
        protected Creator(string ipAddress, string email, string password, string username) : base(ipAddress, email,
            password, username)
        {
        }

        public Money Money { get; private set; }
    }
}