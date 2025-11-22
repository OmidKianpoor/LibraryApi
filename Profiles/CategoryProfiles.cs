using AutoMapper;

namespace LibraryApi.Profiles
{
    public class CategoryProfiles:Profile

    {
        public CategoryProfiles()
        {
            CreateMap<Entities.Category, Models.CategoryWithoutBooksDto>();
            CreateMap<Entities.Category, Models.CategoryDto>();
            CreateMap<Models.CategoryWithoutBooksDto,Entities.Category>();
            CreateMap<Models.CategoryForCreateDto, Entities.Category>();
            CreateMap<Entities.Category, Models.CategoryWithoutBooksDto>();
            CreateMap<Models.CategoryForUpdateDto, Entities.Category>();
            CreateMap< Entities.Category, Models.CategoryForUpdateDto>();

        }
       
    }
}
