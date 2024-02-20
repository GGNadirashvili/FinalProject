using AutoMapper;
using BookManager.Dtos;
using BookManager.Models;

namespace BookManager
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, AddBookDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
