using MediatR;

namespace Fennec.Application.Commands.Content
{
    public class CreateNewArticle : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
    }
}