using BookCatalog.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertBookCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
