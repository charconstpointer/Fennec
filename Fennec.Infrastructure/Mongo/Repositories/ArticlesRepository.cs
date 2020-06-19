using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fennec.Core.Entities.Content;
using Fennec.Core.Repositories;
using Fennec.Infrastructure.Mongo.Documents;
using Fennec.Infrastructure.Mongo.Extensions;
using MongoDB.Driver;

namespace Fennec.Infrastructure.Mongo.Repositories
{
    public class ArticlesRepository : IArticlesRepository
    {
        private readonly IMongoCollection<ArticleDocument> _articles;

        public ArticlesRepository(IMongoClient client)
        {
            _articles = client.GetDatabase("Fennec").GetCollection<ArticleDocument>("articles");
        }

        public async Task<Article> Find(Guid id)
        {
            var documents = await _articles.Find(a => a.Id == id).FirstOrDefaultAsync();
            return documents.AsEntity();

        }

        public async Task<IEnumerable<Article>> Find()
        {
            return (await _articles.Find(_ => true).ToListAsync()).AsEntity();
        }

        public async Task Save(Article article)
        {
            var document = article.AsDocument();
            await _articles.InsertOneAsync(document);
        }
    }
}