using System;
using Fennec.Core.Entities;
using Fennec.Core.Entities.Content;
using Fennec.Core.Entities.Users;
using Fennec.Core.Enums;
using Xunit;

namespace Fennec.Tests
{
    public class ArticleTests
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("title", null)]
        [InlineData(null, "description")]
        public void Article_Create_ThrowsWhenInvalidInput(string title, string description)
        {
            var category = new Category(Guid.NewGuid(), "Sports");
            Assert.Throws<ApplicationException>(() =>
                Article.Create(Guid.NewGuid(), title, description, "body", category, ContentState.Created));
        }

        [Theory]
        [InlineData("foo")]
        [InlineData("bar")]
        public void Article_ChangeTitle_ReturnsCorrectTitle(string title)
        {
            var category = new Category(Guid.NewGuid(), "Sports");
            var article = Article.Create(Guid.NewGuid(), "Default title", "description", "body", category,
                ContentState.Created);

            article.ChangeTitle(title);
            Assert.Equal(title, article.Title);
        }

        [Theory]
        [InlineData("new description")]
        [InlineData("newer description")]
        [InlineData("newest description")]
        public void Article_ChangeDescription_ReturnsCorrectDescription(string description)
        {
            var category = new Category(Guid.NewGuid(), "Sports");
            var article = Article.Create(Guid.NewGuid(), "Default title", "description", "body", category,
                ContentState.Created);

            article.ChangeDescription(description);
            Assert.Equal(description, article.Description);
        }

        [Theory]
        [InlineData("new description")]
        [InlineData("newer description")]
        [InlineData("newest description")]
        public void Article_ChangeBody_ReturnsCorrectDescription(string body)
        {
            var category = new Category(Guid.NewGuid(), "Sports");
            var article = Article.Create(Guid.NewGuid(), "Default title", "description", "body", category,
                ContentState.Created);

            article.ChangeBody(body);
            Assert.Equal(body, article.Body);
        }

        [Fact]
        public void Article_AddComment_CreatesConnectionBetweenObjects()
        {
            var category = new Category(Guid.NewGuid(), "Sports");
            var user = RegisteredUser.Create(Guid.NewGuid(), "email@email.com", "fdjkslfjlsd", "user1", "cantbenull");
            var comment = Comment.Create(Guid.NewGuid(), "some comment", user);
            var article = Article.Create(Guid.NewGuid(), "Default title", "description", "body", category,
                ContentState.Created);
            article.AddComment(comment);
            Assert.Equal(user, comment.Author);
            Assert.Equal(article, comment.Content);
            Assert.Contains(comment, article.Comments);
            Assert.Contains(comment, user.UserComments);
        }
    }
}