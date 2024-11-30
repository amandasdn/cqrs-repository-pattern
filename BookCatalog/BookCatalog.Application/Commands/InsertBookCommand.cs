using BookCatalog.Domain.Entities;
using MediatR;

namespace BookCatalog.Application.Commands
{
    public class InsertBookCommand(Guid id, string title, string author, DateTime publishDate, string genre)
        : IRequest<Guid>
    {
        public Guid Id { get; set; } = id;
        public string Title { get; set; } = title;
        public string Author { get; set; } = author;
        public DateTime PublishDate { get; set; } = publishDate;
        public string Genre { get; set; } = genre;

        public BookEntity ToEntity()
            => new(Title, Author, PublishDate, Genre);
    }
}
