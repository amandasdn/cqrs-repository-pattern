using BookCatalog.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Application.Commands
{
    public class InsertBookCommand(string title, string author, DateTime publishDate, string genre)
        : IRequest<Guid>
    {
        public string Title { get; set; } = title;

        public string Author { get; set; } = author;

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = publishDate;

        public string Genre { get; set; } = genre;

        public BookEntity ToEntity()
            => new(Title, Author, PublishDate, Genre);
    }
}
