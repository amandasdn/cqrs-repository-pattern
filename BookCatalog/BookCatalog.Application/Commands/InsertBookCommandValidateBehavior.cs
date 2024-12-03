using BookCatalog.Domain.Interfaces;
using MediatR;
using System.Data;

namespace BookCatalog.Application.Commands
{
    public class InsertBookCommandValidateBehavior(IBookRepository bookRepository) : IPipelineBehavior<InsertBookCommand, Guid>
    {
        private readonly IBookRepository _bookRepository = bookRepository
            ?? throw new ArgumentNullException(nameof(bookRepository));

        public async Task<Guid> Handle(InsertBookCommand request, RequestHandlerDelegate<Guid> next, CancellationToken cancellationToken)
        {
            var booksWithSameName = await _bookRepository.GetBookByTitleName(request.Title);

            var bookExists = booksWithSameName
                .Any(x =>
                    x.PublishDate == request.PublishDate &&
                    x.Author == request.Author &&
                    x.Genre == request.Genre
                );

            if (bookExists)
            {
                throw new DuplicateNameException($"Book {request.Title} already exists.");
            }

            return await next();
        }
    }
}
