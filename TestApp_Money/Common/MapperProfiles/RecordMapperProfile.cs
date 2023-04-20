using AutoMapper;
using TestApp_Money.UseCases.Features.Records.Queries.GetRecordsByPages;
using TestApp_Money.Web.Models;

namespace TestApp_Money.Web.Common.MapperProfiles
{
    public class RecordMapperProfile : Profile
    {
        public RecordMapperProfile()
        {
            CreateMap<RecordListItem, RecordViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value));
        }
    }
}
