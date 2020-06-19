using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fennec.Core.Entities.Content;

namespace Fennec.Core.Repositories
{
    public interface IContentsRepository
    {
        Task<IEnumerable<Content>> Find(Expression<Func<Article, bool>> predicate);
        Task Save(Article article);
    }
}