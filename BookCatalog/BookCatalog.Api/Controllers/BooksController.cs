using BookCatalog.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator, ILogger<BooksController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertBookCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok();
        }
    }
}
