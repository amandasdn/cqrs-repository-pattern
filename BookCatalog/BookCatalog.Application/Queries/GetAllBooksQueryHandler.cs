using AutoMapper;
using BookCatalog.Application.DTOs;
using BookCatalog.Domain.Interfaces;
using MediatR;

namespace BookCatalog.Application.Queries
{
    public class GetAllBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
        : IRequestHandler<GetAllBooksQuery, List<BookDto>>
    {
        private readonly IBookRepository _bookRepository = bookRepository
            ?? throw new ArgumentNullException(nameof(bookRepository));

        private readonly IMapper _mapper = mapper
            ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<List<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var booksEntity = await _bookRepository.GetAll();

            return _mapper.Map<List<BookDto>>(booksEntity);
        }
    }
}
