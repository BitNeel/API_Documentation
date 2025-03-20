using library.core;
using library.core.Dtos;
namespace library.application
{
    public interface IBookService
    {
        Task<Book?> GetBookByID(long id);
        Task<List<BookDto>> SearchBookByName(string name);
        Task<List<BookDto>> SearchBookByISBN(string ISBN);
        Task<List<BookDto>> GetAllBooks();
    }
}
