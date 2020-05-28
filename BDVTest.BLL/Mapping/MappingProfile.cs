using AutoMapper;
using BDVTest.BLL.DTO;
using BDVTest.DAL.Models;

namespace BDVTest.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WorkSheetOneDto, WorkSheetOne>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreationTime, opt => opt.Ignore());
            CreateMap<WorkSheetOne, WorkSheetOneDto>();

            CreateMap<WorkSheetTwoDto, WorkSheetTwo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreationTime, opt => opt.Ignore());
            CreateMap<WorkSheetTwo, WorkSheetTwoDto>();
        }
    }
}