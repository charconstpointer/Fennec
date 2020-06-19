using System.Collections.Generic;
using Fennec.Application.DTO;
using MediatR;

namespace Fennec.Application.Queries.Users
{
    public class GetAllUsers : IRequest<IEnumerable<UserDto>>
    {
        
    }
}