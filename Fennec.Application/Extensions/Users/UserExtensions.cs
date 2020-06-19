using System.Collections.Generic;
using System.Linq;
using Fennec.Application.DTO;
using Fennec.Application.Extensions.Content;
using Fennec.Core.Entities.Users;

namespace Fennec.Application.Extensions.Users
{
    public static class UserExtensions
    {
        public static UserDto AsDto(this RegisteredUser user)
            => new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                IsBanned = user.IsBanned,
                Comments = user.UserComments.AsDto()
            };

        public static IEnumerable<UserDto> AsDto(this IEnumerable<RegisteredUser> users)
            => users.Select(AsDto);
    }
}