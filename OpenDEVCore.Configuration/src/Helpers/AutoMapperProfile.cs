using AutoMapper;
using Core.Exceptions;
using OpenDEVCore.Configuration.Dto;
using OpenDEVCore.Configuration.Entities;
using System;
using static Core.General.CoreAutoMapperSet;

namespace OpenDEVCore.Configuration.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Catalogue, CatalogueDto>().ReverseMap();
            CreateMap<CatalogueDetail, CatalogueDetailDto>().ReverseMap();
            CreateMap<Catalogue, CatalogueDto>().ReverseMap();
            CreateMap<Parameter, ParameterDto>().ReverseMap();
            CreateMap<Institution, InstitutionDto>().ReverseMap();
            CreateMap<Office, OfficeDto>().ReverseMap();
            CreateMap<Holiday, HolidayDto>().ReverseMap();
            CreateMap<GeographicLocation1, GeographicLocation1Dto>().ReverseMap();
            CreateMap<GeographicLocation2, GeographicLocation2Dto>().ReverseMap();
            CreateMap<GeographicLocation3, GeographicLocation3Dto>().ReverseMap();
            CreateMap<GeographicLocation4, GeographicLocation4Dto>().ReverseMap();


            CreateMap<GeographicLocation1, LightGeographicLocation>()
                 .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.IdGeographicLocation1))
                 .ForMember(dest => dest.Code, opts => opts.MapFrom(src => src.GeographicLocation1Code));
            CreateMap<GeographicLocation2, LightGeographicLocation>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.IdGeographicLocation2))
                 .ForMember(dest => dest.Code, opts => opts.MapFrom(src => src.GeographicLocation2Code));
            CreateMap<GeographicLocation3, LightGeographicLocation>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.IdGeographicLocation3))
                 .ForMember(dest => dest.Code, opts => opts.MapFrom(src => src.GeographicLocation3Code));
            CreateMap<GeographicLocation4, LightGeographicLocation>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.IdGeographicLocation4))
                 .ForMember(dest => dest.Code, opts => opts.MapFrom(src => src.GeographicLocation4Code));

            CreateMap<EsbendPoint, EsbendPointDto>().ReverseMap();
            CreateMap<Esbexception, EsbexceptionDto>().ReverseMap();
            //CreateMap<EsbendPointException, EsbendPointExceptionDto>()
            //.ForMember(dest => dest.Key, opts => opts.MapFrom(src => string.Format("{0} {1}", src.IdEsbendPointNavigation.Code, src.EndPointErrorCode))).ReverseMap();

            CreateMap<EsbendPointException, EsbendPointExceptionDto>()
            .ForMember(dest => dest.Key, opts => opts.MapFrom(src => $"{src.IdEsbendPointNavigation.Code} {src.EndPointErrorCode}")).ReverseMap();


            CreateMap<EsbendPointExceptionDto, ResourceExDescription>()
               .ForMember(dest => dest.code, opts => opts.MapFrom(src => src.IdEsbexceptionNavigation.ErrorCode))
               .ForMember(dest => dest.message, opts => opts.MapFrom(src => src.IdEsbexceptionNavigation.Description))
               .ForMember(dest => dest.ext_code, opts => opts.MapFrom(src => src.EndPointErrorCode))
               .ForMember(dest => dest.ext_message, opts => opts.MapFrom(src => src.EndPointMessage));

            CreateMap<DateTime, long>().ConvertUsing(new DateTimeLongTypeConverter());
            CreateMap<long, DateTime>().ConvertUsing(new LongDateTimeTypeConverter());

        }
    }
}
