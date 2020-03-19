using AutoMapper;
using OpenDevCore.DocConfiguration;
using OpenDevCore.DocConfiguration.Entities;
using OpenDevCore.DocConfiguration.Dto;

using System;
using static Core.General.CoreAutoMapperSet;


namespace OpenDevCore.OpenDevCore.DocConfiguration.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //********************************MAPS for TypeDocument*****************************
            CreateMap<TypeDocument, TypeDocumentDto>().ReverseMap();
            CreateMap<TypeDocument, TypeDocumentDto>();

            //MAPS for Area
            CreateMap<Area, AreaDto>().ReverseMap();
            CreateMap<Area, AreaDto>();

            //MAPS for AreaOcr
            CreateMap<AreaOcr, AreaDto>().ReverseMap();
            CreateMap<Area, AreaDto>();

            //MAPS for TypeDctoField
            CreateMap<TypeDctoField, TypeDctoFieldDto>().ReverseMap();
            CreateMap<TypeDctoField, TypeDctoFieldDto>();


            ////********************************MAPS for Field//********************************
            CreateMap<Field, FieldDto>().ReverseMap();
            CreateMap<Field, FieldDto>();

            //********************************MAPS for TypeFolder//********************************

            CreateMap<TypeFolder, TypeFolderDto>().ReverseMap();
            CreateMap<TypeFolder, TypeFolderDto>();

            //Maps for TypeDctoFolder
            CreateMap<TypeDctoFolder, TypeDctoFolderDto>().ReverseMap();
            CreateMap<TypeDctoFolder, TypeDctoFolderDto>();

            //Maps for FieldFolderField 
            CreateMap<TypeFolderField, TypeFolderFieldDto>().ReverseMap();
            CreateMap<TypeFolderField, TypeFolderFieldDto>();


            ////********************************MAPS for TypeImage//********************************
            CreateMap<TypeImage, TypeImageDto>().ReverseMap();
            CreateMap<TypeImage, TypeImageDto>();

            ////********************************MAPS for Typebox//********************************
            CreateMap<TypeBox, TypeBoxDto>().ReverseMap();
            CreateMap<TypeBox, TypeBoxDto>();

            //Maps for TypeBoxField
            CreateMap<TypeBoxField, TypeBoxFieldDto>().ReverseMap();
            CreateMap<TypeBoxField, TypeBoxFieldDto>().ReverseMap();

            ////********************************MAPS for Forms//********************************
            CreateMap<FormVersion, FormVersionDto>().ReverseMap();
            CreateMap<FormVersion, FormVersionDto>();

            //Maps for TypeBoxField
            CreateMap<WaterMark, WaterMarkDto>().ReverseMap();
            CreateMap<WaterMark, WaterMarkDto>().ReverseMap();

            //Maps for Utils
            CreateMap<DateTime, long>().ConvertUsing(new DateTimeLongTypeConverter());
            CreateMap<long, DateTime>().ConvertUsing(new LongDateTimeTypeConverter());
        }
    }
}
