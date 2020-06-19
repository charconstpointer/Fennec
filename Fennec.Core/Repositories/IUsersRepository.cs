using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fennec.Core.Entities.Users;

namespace Fennec.Core.Repositories
{
    public interface IUsersRepository
    {
        Task<RegisteredUser> Find(Guid id);
        Task<IEnumerable<RegisteredUser>> Find();
        Task Save(RegisteredUser t);
    }
}