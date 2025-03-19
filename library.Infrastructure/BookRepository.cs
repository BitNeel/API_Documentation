using library.core;
using library.data;
using Microsoft.EntityFrameworkCore;

namespace library.Infrastructure
{
    internal class BookRepository : IRepository<Book>
    {
        private readonly LibraryDBContext _dbContext;

        public BookRepository(LibraryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book?> GetEntityById(long id)
        {
            Book? book = await _dbContext.Books.FindAsync(id);
            return book;
        }

        public async Task<List<Book>> ListAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<List<Book>> ListAsync(Func<Book, bool> predicate)
        {
            return await _dbContext.Books.Where(predicate).AsQueryable().ToListAsync();
        }
    }
}
