using System;
using Fennec.Core.Entities;
using Fennec.Core.Entities.Users;
using Xunit;

namespace Fennec.Tests
{
    public class AuthorTests
    {
        [Fact]
        public void Author_AddComment_CreatesConnectionBetweenObjects()
        {
            var user = RegisteredUser.Create(Guid.NewGuid(), "email@email.com", "fdjkslfjlsd", "user1", "cantbenull");
            var comment = Comment.Create(Guid.NewGuid(), "some comment", user);
            user.AddComment(comment);
            Assert.Equal(user, comment.Author);
            Assert.Equal(comment.Author, user);
        }
    }
}