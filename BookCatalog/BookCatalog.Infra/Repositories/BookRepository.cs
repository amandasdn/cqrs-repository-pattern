using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Interfaces;

namespace BookCatalog.Infra.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly MongoDbContext _context;

        public BookRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Add(BookEntity book)
        {
            await _context.Books.InsertOneAsync(book);

            return book.Id;
        }

        public async Task<List<BookEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<BookEntity?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
