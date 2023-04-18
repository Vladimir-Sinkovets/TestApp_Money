using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp_Money.Entites.Models;
using TestApp_Money.UseCases.Features.Categories.Queries.GetAllCategoriesForUser;

namespace TestApp_Money.UseCases.Common
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
