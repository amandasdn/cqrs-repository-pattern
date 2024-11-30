using BookCatalog.Domain.Interfaces;
using MediatR;

namespace BookCatalog.Application.Commands
{
    public class InsertBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<InsertBookCommand, Guid>
    {
        private readonly IBookRepository _bookRepository = bookRepository
            ?? throw new ArgumentNullException(nameof(bookRepository));

        public async Task<Guid> Handle(InsertBookCommand request, CancellationToken cancellationToken)
        {
            var book = request.ToEntity();

            var resultId = await _bookRepository.Add(book);

            return resultId;
        }
    }
}
