using System;
using System.Threading;
using System.Threading.Tasks;
using Fennec.Application.Commands.Users;
using Fennec.Core.Entities.Users;
using Fennec.Core.Repositories;
using MediatR;

namespace Fennec.Application.Handlers.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUser>
    {
        private readonly IUsersRepository _usersRepository;

        public CreateUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<Unit> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var user = RegisteredUser.Create(Guid.NewGuid(), "3213212", request.Username, request.Email, request.Password);
            await _usersRepository.Save(user);
            return Unit.Value;
        }
    }
}