using API.Class1.v1.Models;
using AutoMapper;
using DataAccess.Class1.v1.DataEntities;
using System;

namespace API.Class1.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region V1 Mappings
            // Class1 Mappings
            CreateMap<Class1TableEntity, Class1Model>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => Guid.Parse(src.RowKey)));

            CreateMap<Class1AddModel, Class1TableEntity>()
                .ForMember(dest => dest.RowKey, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedOnUTCDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOnUTCDate, opt => opt.Ignore());

            CreateMap<Class1UpdateModel, Class1TableEntity>()
                .ForMember(dest => dest.RowKey, opt => opt.MapFrom(src => src.ID.ToString()))
                .ForMember(dest => dest.CreatedOnUTCDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedOnUTCDate, opt => opt.Ignore());
            #endregion
        }
    }
}
