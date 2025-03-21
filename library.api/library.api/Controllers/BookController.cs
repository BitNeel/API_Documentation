using library.application;
using library.core;
using library.core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace library.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController: ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> SearchAllBooks(string? bookName, string? ISBN)
        {
            List<BookDto> bookList = await _bookService.BooksSearch(bookName, ISBN);
            foreach (var book in bookList)
            {
                book._links = new EntityLink { Self = Url.Action(action: nameof(GetBookbyId), controller: "Book", values: new { Id = book.Id }, protocol: Request.Scheme) };
            }
            return Ok(bookList);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<Book>> GetBookbyId(long id)
        {
            Book? found_book = await _bookService.GetBookByID(id);
            if (found_book == null) return NoContent();
            else return Ok(found_book);
        }
    }
}
