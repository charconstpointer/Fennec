using MediatR;

namespace Fennec.Application.Commands.Users
{
    public class CreateUser : IRequest
    {
        public string Username { get; set; }
        public string Email { get;  set; }
        public string Password { get;  set; }
    }
}