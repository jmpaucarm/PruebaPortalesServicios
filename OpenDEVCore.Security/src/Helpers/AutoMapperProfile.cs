using System;
using OpenDEVCore.Security.Entities;
using OpenDEVCore.Security.Dto;
using static Core.General.CoreAutoMapperSet;

namespace OpenDEVCore.Security.Helpers
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
                CreateMap<User, UserDto>().ReverseMap();
                CreateMap<User, AddUserDto>().ReverseMap();
                CreateMap<User, EditUserDto>().ReverseMap();
                CreateMap<UserProfile, UserProfileDto>().ReverseMap();
                CreateMap<Entities.Profile, ProfileDto>().ReverseMap();
                CreateMap<Entities.ProfileOption, ProfileOptionDto>().ReverseMap();
                CreateMap<Option, OptionDto>().ReverseMap();
                CreateMap<DateTime, long>().ConvertUsing(new DateTimeLongTypeConverter());
                CreateMap<long, DateTime>().ConvertUsing(new LongDateTimeTypeConverter());
                CreateMap<Menu, MenuDto>().ReverseMap();
                //ValidateInlineMaps = false;
        }
    }
}
