using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fennec.Core.Entities.Content;

namespace Fennec.Core.Repositories
{
    public interface IArticlesRepository
    {
        Task<Article> Find(Guid id);
        Task<IEnumerable<Article>> Find();
        Task Save(Article article);
    }
}