using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Fennec.Application.DTO;
using Fennec.Application.Extensions.Content;
using Fennec.Application.Queries.Content;
using Fennec.Core.Repositories;
using MediatR;

namespace Fennec.Application.Handlers.Content
{
    public class GetAllArticlesHandler : IRequestHandler<GetAllArticles, IEnumerable<ArticleDto>>
    {
        private readonly IArticlesRepository _articlesRepository;

        public GetAllArticlesHandler(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public async Task<IEnumerable<ArticleDto>> Handle(GetAllArticles request, CancellationToken cancellationToken)
        {
            var articles = await _articlesRepository.Find();
            return articles.AsDto();
        }
    }
}