using AutoMapper;
using BookCatalog.Application.DTOs;
using BookCatalog.Domain.Interfaces;
using MediatR;

namespace BookCatalog.Application.Commands
{
    public class InsertBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        : IRequestHandler<InsertBookCommand, BookDto>
    {
        private readonly IBookRepository _bookRepository = bookRepository
            ?? throw new ArgumentNullException(nameof(bookRepository));

        private readonly IMapper _mapper = mapper
            ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<BookDto> Handle(InsertBookCommand request, CancellationToken cancellationToken)
        {
            var bookEntity = request.ToEntity();

            var createdBookId = await _bookRepository.Add(bookEntity);

            bookEntity.Id = createdBookId;

            return _mapper.Map<BookDto>(bookEntity);
        }
    }
}
