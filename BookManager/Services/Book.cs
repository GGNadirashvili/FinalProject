using AutoMapper;
using BookManager.Data;
using BookManager.Dtos;
using Microsoft.EntityFrameworkCore;
using RPGSln.Models;

namespace BookManager.Services
{
    public class Book : IBook
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public Book(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<ServiceResponse<List<BookDto>>> AddBook(AddBookDto newBook)
        {
            var serviceResponse = new ServiceResponse<List<BookDto>>();

            var book = mapper.Map<Models.Book>(newBook);

            context.Books.Add(book);
            await context.SaveChangesAsync();

            var books = await context.Books.ToListAsync();
            serviceResponse.Data = mapper.Map<List<BookDto>>(books);

            return serviceResponse;
        }


        public async Task<ServiceResponse<BookDto>> DeleteBook(int id)
        {
            var serviceResponse = new ServiceResponse<BookDto>();

            try
            {
                var book = await context.Books
                        .FirstOrDefaultAsync(x => x.Id == id);
                if (book is null)
                {
                    serviceResponse.Message = $"book with id '{id}'  not found";
                }

                context.Books.Remove(book!);
                await context.SaveChangesAsync();

                serviceResponse.Data = mapper.Map<BookDto>(book);
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<BookDto>>> GetAllBook()
        {
            var serviceResponse = new ServiceResponse<List<BookDto>>();
            var books = await context.Books.ToListAsync();

            serviceResponse.Data = books.Select(books => mapper.Map<BookDto>(books)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<BookDto>> GetBookByTitle(string title)
        {
            var serviceResponse = new ServiceResponse<BookDto>();
            var book = await context.Books.FirstOrDefaultAsync(x => x.Title!.Contains(title));

            if (book is null)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = $"Book with title '{title}' not found";
            }
            else
            {
                serviceResponse.Data = mapper.Map<BookDto>(book);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<BookDto>> UpdateBook(BookDto updatedBook)
        {
            var serviceResponse = new ServiceResponse<BookDto>();

            try
            {
                var book = await context.Books.FirstOrDefaultAsync(x => x.Id == updatedBook.Id);
                if (book is null)
                {
                    serviceResponse.Message = $"book with id '{updatedBook.Id}'  not found";
                }

                book!.Title = updatedBook.Title;
                book.Author = updatedBook.Author;


                serviceResponse.Data = mapper.Map<BookDto>(book);

                await context.SaveChangesAsync();

                serviceResponse.Data = mapper.Map<BookDto>(book);
                return serviceResponse;

            }
            catch (Exception ex)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

       
    }
}
