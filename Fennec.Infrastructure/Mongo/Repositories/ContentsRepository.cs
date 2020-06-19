using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fennec.Core.Entities.Content;
using Fennec.Core.Repositories;
using MongoDB.Driver;

namespace Fennec.Infrastructure.Mongo.Repositories
{
    public class ContentsRepository : IContentsRepository
    {
        private readonly IMongoCollection<Article> _articles;

        public ContentsRepository(IMongoClient client)
        {
            _articles = client.GetDatabase("Fennec").GetCollection<Article>("articles");
        }

        public async Task<IEnumerable<Content>> Find(Expression<Func<Article, bool>> predicate)
        {
            return await _articles.Find(predicate).ToListAsync();
        }

        public async Task Save(Article article)
        {
            await _articles.InsertOneAsync(article);
        }
    }
}