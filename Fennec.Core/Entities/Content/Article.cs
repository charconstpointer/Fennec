using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Fennec.Core.Enums;

namespace Fennec.Core.Entities.Content
{
    public class Article : Content, IContent
    {
        public IReadOnlyCollection<string> Tags => _tags.ToImmutableList();
        private readonly ICollection<string> _tags;
        public IReadOnlyCollection<Advertisement> Advertisements => _advertisements.ToImmutableList();
        private readonly ICollection<Advertisement> _advertisements;
        public IReadOnlyCollection<Comment> Comments => _comments.ToImmutableList();
        private readonly ISet<Comment> _comments;

        public string Body { get; private set; }

        private Article(Guid id, string title, string description, string body, Category category, ContentState state,
            bool isAdvertisementEnabled = false, bool isDeleted = false,
            ISet<string> tags = null,
            ISet<Advertisement> advertisements = null, ISet<Comment> comments = null) : base(id, title,
            description, category, state,
            isAdvertisementEnabled, isDeleted)
        {
            _tags = tags ?? new HashSet<string>();
            _advertisements = advertisements ?? new HashSet<Advertisement>();
            Body = body;
            _comments = comments ?? new HashSet<Comment>();
        }

        public static Article Create(Guid id, string title, string description, string body, Category category,
            ContentState state,
            bool isAdvertisementEnabled = false, bool isDeleted = false, ISet<string> tags = null,
            ISet<Advertisement> advertisements = null, ISet<Comment> comments = null)
        {
            ValidateInputs(title, description);

            var article = new Article(id, title, description, body, category, state, isAdvertisementEnabled, isDeleted,
                tags, advertisements, comments);
            return article;
        }

        private static void ValidateInputs(params string[] parameters)
        {
            foreach (var parameter in parameters)
            {
                if (string.IsNullOrEmpty(parameter))
                {
                    throw new ApplicationException($"{nameof(parameter)} cannot be empty or null");
                }
            }
        }

        public void ChangeTitle(string title)
        {
            ValidateInputs(title);
            Title = title;
        }

        public void ChangeDescription(string description)
        {
            ValidateInputs(description);
            Description = description;
        }

        public void ChangeBody(string body)
        {
            ValidateInputs(body);
            Body = body;
        }

        public void AddComment(Comment comment)
        {
            if (comment is null)
            {
                throw new ApplicationException("Comment cannot be null");
            }

            if (comment.Author is null)
            {
                throw new ApplicationException("Comment must have an author");
            }

            if (_comments.Contains(comment))
            {
                return;
            }

            _comments.Add(comment);
            var author = comment.Author;
            comment.Content = this;
            comment.Author = author;
            author.AddComment(comment);
        }
    }
}