using System.Collections.Generic;
using System.Linq;
using Fennec.Application.DTO;
using Fennec.Core.Entities.Content;

namespace Fennec.Application.Extensions.Content
{
    public static class ArticleExtensions
    {
        public static ArticleDto AsDto(this Article article)
            => new ArticleDto
            {
                Advertisements = article.Advertisements,
                Body = article.Body,
                Category = article.Category?.Name,
                Comments = article.Comments,
                Description = article.Description,
                Id = article.Id,
                Tags = article.Tags,
                Title = article.Title,
                IsAdvertisementEnabled = article.IsAdvertisementEnabled
            };
    
        public static IEnumerable<ArticleDto> AsDto(this IEnumerable<Article> articles)
            => articles.Select(AsDto);
    }
}