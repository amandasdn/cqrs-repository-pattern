namespace BookCatalog.Domain.Entities
{
    public class BookEntity : BaseEntity
    {
        public BookEntity(string title, string author, DateTime publishDate, string genre)
            : base()
        {
            Title = title;
            Author = author;
            PublishDate = publishDate;
            Genre = genre;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public DateTime PublishDate { get; private set; }
        public string Genre { get; private set; }

    }
}
