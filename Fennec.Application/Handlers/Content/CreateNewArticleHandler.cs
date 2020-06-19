using System;
using System.Threading;
using System.Threading.Tasks;
using Fennec.Application.Commands.Content;
using Fennec.Core.Entities.Content;
using Fennec.Core.Enums;
using Fennec.Core.Repositories;
using MediatR;

namespace Fennec.Application.Handlers.Content
{
    public class CreateNewArticleHandler : IRequestHandler<CreateNewArticle>
    {
        private readonly IArticlesRepository _articlesRepository;

        public CreateNewArticleHandler(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public async Task<Unit> Handle(CreateNewArticle request, CancellationToken cancellationToken)
        {
            var article = Article.Create(Guid.NewGuid(), request.Title, request.Description, request.Body, null,
                ContentState.Created);
            await _articlesRepository.Save(article);
            return Unit.Value;
        }
    }
}