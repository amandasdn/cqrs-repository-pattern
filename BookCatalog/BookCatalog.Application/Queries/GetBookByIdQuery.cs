using BookCatalog.Application.DTOs;
using MediatR;

namespace BookCatalog.Application.Queries
{
    public class GetBookByIdQuery(string id)
        : IRequest<BookDto>
    {
        public string Id { get; set; } = id;
    }
}
