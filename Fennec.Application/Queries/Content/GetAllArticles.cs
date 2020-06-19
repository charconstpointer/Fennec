using System.Collections.Generic;
using Fennec.Application.DTO;
using MediatR;

namespace Fennec.Application.Queries.Content
{
    public class GetAllArticles : IRequest<IEnumerable<ArticleDto>>
    {
        
    }
}