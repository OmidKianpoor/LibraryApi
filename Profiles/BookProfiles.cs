using AutoMapper;

namespace LibraryApi.Profiles
{
    public class BookProfiles :Profile
    {
        public BookProfiles()
        {
            CreateMap<Entities.Book,Models.BookDto>();
            CreateMap<Models.BookForCreateDto, Entities.Book>();
            CreateMap<Models.BookForEditDto, Entities.Book>();
            CreateMap< Entities.Book, Models.BookForEditDto>();
        }
    }
}
