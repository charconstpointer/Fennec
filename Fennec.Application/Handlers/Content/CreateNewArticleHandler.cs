using System;
using System.Threading;
using System.Threading.Tasks;
using Fennec.Application.Commands.Content;
using Fennec.Core.Entities;
using Fennec.Core.Entities.Content;
using Fennec.Core.Enums;
using Fennec.Core.Repositories;
using MediatR;

namespace Fennec.Application.Handlers.Content
{
    public class CreateNewArticleHandler : IRequestHandler<CreateNewArticle>
    {
        private readonly IContentsRepository _contentsRepository;

        public CreateNewArticleHandler(IContentsRepository contentsRepository)
        {
            _contentsRepository = contentsRepository;
        }

        public async Task<Unit> Handle(CreateNewArticle request, CancellationToken cancellationToken)
        {
            var article = Article.Create(Guid.NewGuid(), request.Title, request.Description, request.Body, null,
                ContentState.Created);
            throw new System.NotImplementedException();
        }
    }
}