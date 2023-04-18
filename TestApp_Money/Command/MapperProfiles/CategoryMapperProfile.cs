using AutoMapper;
using TestApp_Money.UseCases.Features.Categories.Queries.GetAllCategoriesForUser;
using TestApp_Money.Web.Models;

namespace TestApp_Money.Web.Command.MapperProfiles
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile() 
        {
            CreateMap<CategoryDto, CategoryData>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
