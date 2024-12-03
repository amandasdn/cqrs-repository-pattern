using BookCatalog.Domain.Entities;

namespace BookCatalog.Domain.Interfaces
{
    public interface IBookRepository : IRepository<BookEntity>
    {
        Task<List<BookEntity>> GetBookByTitleName(string title);
    }
}
