using System.Linq.Expressions;
using library.core;
using library.core.Dtos;
using Microsoft.EntityFrameworkCore;
namespace library.application
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _repo;

        public BookService(IRepository<Book> repo)
        {
            _repo = repo;
        }

        public async Task<Book?> GetBookByID(long id)
        {
            Book? found_book = await _repo.GetEntityById(id);
            return found_book;
        }

        public async Task<List<BookDto>> BooksSearch(string? BookName, string? ISBN)
        {
            Expression<Func<Book, bool>> predicate = b => true;
            if (!string.IsNullOrEmpty(BookName))
            {
                predicate = b => b.Title.Contains(BookName);
                if (!string.IsNullOrEmpty(ISBN))
                {
                    predicate = b => b.Title.Contains(BookName) && b.ISBN.Contains(ISBN);
                }
            }
            else if (!string.IsNullOrEmpty(ISBN))
            {
                predicate = b => b.ISBN.Contains(ISBN);
            }
            return await _repo.ListAsync(predicate)
                .Select(b=> new BookDto {Id=b.ID,Title=b.Title, ISBN = b.ISBN})
                .ToListAsync();
        }
    }
}
