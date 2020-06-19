using System.Threading.Tasks;
using Fennec.Application.Commands.Content;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fennec.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("articles")]
        public async Task<IActionResult> CreateNewArticle(CreateNewArticle command)
        {
            return Created("", await _mediator.Send(command));
        }
    }
}