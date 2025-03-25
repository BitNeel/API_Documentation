using System.Linq.Expressions;
using library.core;
using Microsoft.EntityFrameworkCore;

namespace library.Infrastructure
{
    public class BookRepository : IRepository<Book>
    {
        private readonly LibraryDBContext _dbContext;

        public BookRepository(LibraryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book?> GetEntityById(long id)
        {
            Book? book = await _dbContext.Books.FindAsync(id);
            if (book != null)
            {
                await _dbContext.Entry(book).Reference(b => b.Category).LoadAsync();
            }
            return book;
        }

        public IQueryable<Book> ListAsync()
        {
            return  _dbContext.Books;
        }

        public IQueryable<Book> ListAsync(Expression<Func<Book, bool>> predicate)
        {
            return _dbContext.Books.Where(predicate);
        }
    }
}
