using BookManager.Dtos;
using BookManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    public class BookController : ControllerBase
    {
        private readonly IBook bookService;

        public BookController(IBook bookService)
        {
            this.bookService = bookService;
        }


        [HttpPost("AddBook")]
        public async Task<ActionResult<BookDto>> AddBook(AddBookDto newBook)
        {
            return Ok(await bookService.AddBook(newBook));
        }

        [HttpGet("GetAllBook")]

        public async Task<ActionResult<List<BookDto>>> GetAllBook()
        {
            return Ok(await bookService.GetAllBook());
        }

        [HttpGet("GetBookByTitle/{title}")]

        public async Task<ActionResult<BookDto>> GetBookByTitle(string title)
        {
            return Ok(await bookService.GetBookByTitle(title));
        }

        [HttpPut("UpdateBook")]

        public async Task<ActionResult<BookDto>> UpdateBook(BookDto updatedBook)
        {
            return Ok(await bookService.UpdateBook(updatedBook));
        }

        [HttpDelete("DeleteBook")]

        public async Task<ActionResult<BookDto>> DeleteBook(int id)
        {
            return Ok(await bookService.DeleteBook(id));
        }
    }
}

