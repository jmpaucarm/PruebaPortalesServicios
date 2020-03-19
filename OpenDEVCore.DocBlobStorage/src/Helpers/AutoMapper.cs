using AutoMapper;
using Core.Types;
using OpenDEVCore.DocBlobStorage.Dto;
using OpenDEVCore.DocBlobStorage.Entities;

using System;
using static Core.General.CoreAutoMapperSet;


namespace OpenDEVCore.DocBlobStorage.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //map for document 

            CreateMap<Document, DocumentDto>().ReverseMap();
            CreateMap<Document, DocumentDto>();

            //map for document Field
            CreateMap<DocumentField, DocumentFieldDto>().ReverseMap();
            CreateMap<DocumentField, DocumentFieldDto>();

            //MAP DOCUMENT A FIELD 
            CreateMap<DocumentDto, DtoFile>()
                .ForMember(dest => dest.data, opts => opts.MapFrom(src => src.Data))
                .ForMember(dest => dest.name, opts => opts.MapFrom(src => src.CodeDocument))
                .ForMember(dest => dest.documentType, opts => opts.MapFrom(src => src.Type));

            //Map  Document to DocumentNoData

            CreateMap<Document, DocumentNoDataDto>()
                  .ForMember(dest => dest.IdDocument, opts => opts.MapFrom(src => src.IdDocument))
                .ForMember(dest => dest.CodeTypeDocument, opts => opts.MapFrom(src => src.CodeTypeDocument))
                .ForMember(dest => dest.CodeDocument, opts => opts.MapFrom(src => src.CodeDocument))
                .ForMember(dest => dest.Institution, opts => opts.MapFrom(src => src.Institution))
                .ForMember(dest => dest.Type, opts => opts.MapFrom(src => src.Type));


            //Map  Document to DocumentNoData

            CreateMap<Folder, FolderDto>();
            CreateMap<Folder, FolderDto>().ReverseMap();


            CreateMap<FolderField, FolderFieldDto>().ReverseMap();
            CreateMap<FolderField, FolderFieldDto>();


            //Map for box

            CreateMap<Box, BoxDto>();
            CreateMap<Box, BoxDto>().ReverseMap();

            CreateMap<BoxField, BoxFieldDto>().ReverseMap();
            CreateMap<BoxField, BoxFieldDto>();






            CreateMap<DateTime, long>().ConvertUsing(new DateTimeLongTypeConverter());
            CreateMap<long, DateTime>().ConvertUsing(new LongDateTimeTypeConverter());
        }
    }
}
