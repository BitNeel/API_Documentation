using library.core;
using library.core.Dtos;
namespace library.application
{
    public interface IBookService
    {
        Task<Book?> GetBookByID(long id);
        Task<List<BookDto>> BooksSearch(string? BookName, string? ISBN);
    }
}
