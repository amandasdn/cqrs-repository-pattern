using AutoMapper;
using BookCatalog.Application.DTOs;
using BookCatalog.Domain.Interfaces;
using MediatR;

namespace BookCatalog.Application.Queries
{
    public class GetBookByIdQueryHandler(IBookRepository bookRepository, IMapper mapper)
        : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private readonly IBookRepository _bookRepository = bookRepository
            ?? throw new ArgumentNullException(nameof(bookRepository));

        private readonly IMapper _mapper = mapper
            ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.Id, out var id))
                throw new ArgumentException("Invalid GUID format for Book ID", nameof(request.Id));

            var booksEntity = await _bookRepository.GetById(id);

            return _mapper.Map<BookDto>(booksEntity);
        }
    }
}
