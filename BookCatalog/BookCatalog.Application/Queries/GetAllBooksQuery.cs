using BookCatalog.Application.DTOs;
using MediatR;

namespace BookCatalog.Application.Queries
{
    public class GetAllBooksQuery : IRequest<List<BookDto>>
    {
    }
}
