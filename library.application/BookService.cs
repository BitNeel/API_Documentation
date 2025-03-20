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

        public async Task<List<BookDto>> GetAllBooks()
        {
            return await _repo.ListAsync()
                .Select(b=> new BookDto { Id=b.ID,Title = b.Title, ISBN = b.ISBN})
                .ToListAsync();
        }

        public async Task<Book?> GetBookByID(long id)
        {
            Book? found_book = await _repo.GetEntityById(id);
            return found_book;
        }

        public async Task<List<BookDto>> SearchBookByISBN(string ISBN)
        {
            return await _repo.ListAsync(b => b.ISBN == ISBN)
                .Select(b=> new BookDto { Id=b.ID,ISBN=b.ISBN, Title=b.Title })
                .ToListAsync();
        }

        public async Task<List<BookDto>> SearchBookByName(string name)
        {
            return await _repo.ListAsync(b => b.Title.Contains(name))
                .Select(b=> new BookDto { Id=b.ID,ISBN=b.ISBN, Title=b.Title})
                .ToListAsync();
        }
    }
}
