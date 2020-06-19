using System.Threading.Tasks;
using Fennec.Application.Commands.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fennec.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUser createUser)
        {
            return Created("", await _mediator.Send(createUser));
            
        }

        #region ...

        // [HttpPost("moderators")]
        // public async Task<IActionResult> CreateModerator(CreateModerator createModerator)
        // {
        //     return Created("", await _mediator.Send(createModerator));
        // }
        //
        // [HttpPost("creators")]
        // public async Task<IActionResult> CreateContentCreator()
        // {
        //     return Created("", await _mediator.Send());
        // }
        //
        // [HttpPost("advertisers")]
        // public async Task<IActionResult> CreateAdvertiser()
        // {
        //     return Created("", await _mediator.Send());
        // }
        

        #endregion
    }
}