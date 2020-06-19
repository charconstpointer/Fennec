using System.Collections.Generic;
using System.Linq;
using Fennec.Core.Entities.Users;
using Fennec.Infrastructure.Mongo.Documents;

namespace Fennec.Infrastructure.Mongo.Extensions
{
    public static class UserDocumentExtensions
    {
        public static RegisteredUser AsEntity(this UserDocument userDocument)
            => RegisteredUser.Create(userDocument.Id, "321321", userDocument.Username, userDocument.Email,
                userDocument.Password, userDocument.Comments.AsEntity(userDocument).ToHashSet());

        public static IEnumerable<RegisteredUser> AsEntity(this IEnumerable<UserDocument> userDocuments)
            => userDocuments.Select(AsEntity);

        public static UserDocument AsDocument(this RegisteredUser registeredUser)
            => new UserDocument
            {
                Email = registeredUser.Email,
                Comments = registeredUser.UserComments.AsDocument(),
                Id = registeredUser.Id,
                Password = registeredUser.Password,
                Username = registeredUser.Username,
                IsBanned = registeredUser.IsBanned
            };
    }
}