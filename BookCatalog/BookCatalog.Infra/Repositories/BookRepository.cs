using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Interfaces;
using MongoDB.Driver;

namespace BookCatalog.Infra.Repositories
{
    public class BookRepository(MongoDbContext context) : IBookRepository
    {
        private readonly MongoDbContext _context = context;

        public async Task<Guid> Add(BookEntity book)
        {
            await _context.Books.InsertOneAsync(book);

            return book.Id;
        }

        public async Task<List<BookEntity>> GetAll()
        {
            var books = await _context.Books.Find(_ => true).ToListAsync();

            return books;
        }

        public async Task<BookEntity?> GetById(Guid id)
        {
            var filter = Builders<BookEntity>.Filter.Eq(b => b.Id, id);

            var book = await _context.Books.Find(filter).FirstOrDefaultAsync();

            return book;
        }

        public async Task<List<BookEntity>> GetBookByTitleName(string title)
        {
            var filter = Builders<BookEntity>.Filter.Eq(b => b.Title, title);

            var books = await _context.Books.Find(filter).ToListAsync();

            return books;
        }
    }
}
