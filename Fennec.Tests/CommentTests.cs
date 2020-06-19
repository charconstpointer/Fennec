using System;
using Fennec.Core.Entities;
using Fennec.Core.Entities.Users;
using Xunit;

namespace Fennec.Tests
{
    public class CommentTests
    {
        [Fact]
        public void Comment_CreateComment_ReturnsNewComment()
        {
            var user = RegisteredUser.Create(Guid.NewGuid(), "email@email.com", "fdjkslfjlsd", "user1", "cantbenull");
            var comment = Comment.Create(Guid.NewGuid(), "some comment", user);
            Assert.NotNull(comment);
            Assert.IsType<Comment>(comment);
        }
    }
}