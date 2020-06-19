using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Fennec.Application.DTO;
using Fennec.Application.Extensions.Users;
using Fennec.Application.Queries.Users;
using Fennec.Core.Repositories;
using MediatR;

namespace Fennec.Application.Handlers.Users
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, IEnumerable<UserDto>>
    {
        private readonly IUsersRepository _usersRepository;

        public GetAllUsersHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            var users = await _usersRepository.Find();
            return users.AsDto();
        }
    }
}