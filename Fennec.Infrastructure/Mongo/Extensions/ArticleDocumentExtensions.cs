using System.Collections.Generic;
using System.Linq;
using Fennec.Core.Entities.Content;
using Fennec.Infrastructure.Mongo.Documents;

namespace Fennec.Infrastructure.Mongo.Extensions
{
    public static class ArticleDocumentExtensions
    {
        public static Article AsEntity(this ArticleDocument document)
            => Article.Create(document.Id, document.Title, document.Description, document.Body, document.Category,
                document.State, document.IsAdvertisementEnabled, document.IsDeleted, document.Tags,
                document.Advertisements, document.Comments);

        public static IEnumerable<Article> AsEntity(this IEnumerable<ArticleDocument> documents)
            => documents.Select(AsEntity);

        public static ArticleDocument AsDocument(this Article article)
            => new ArticleDocument
            {
                Body = article.Body,
                Category = article.Category,
                Description = article.Description,
                Id = article.Id,
                Advertisements = article.Advertisements.ToHashSet(),
                Comments = article.Comments.ToHashSet(),
                State = article.State,
                Tags = article.Tags.ToHashSet(),
                Title = article.Title,
                IsDeleted = article.IsDeleted,
                IsAdvertisementEnabled = article.IsAdvertisementEnabled
            };

        public static IEnumerable<ArticleDocument> AsDocument(this IEnumerable<Article> articles)
            => articles.Select(AsDocument);
    }
}