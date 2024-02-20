using BookManager.Dtos;
using RPGSln.Models;

namespace BookManager.Services
{
    public interface IBook
    {
        Task<ServiceResponse<List<BookDto>>> GetAllBook();
        Task<ServiceResponse<BookDto>> GetBookByTitle(string title);
        Task<ServiceResponse<List<BookDto>>> AddBook(AddBookDto newBook);
        Task<ServiceResponse<BookDto>> DeleteBook(int id);
        Task<ServiceResponse<BookDto>> UpdateBook(BookDto updatedBook);
    }
}
