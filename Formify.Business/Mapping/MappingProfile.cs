using AutoMapper;
using Formify.Business.Dtos.FieldDtos;
using Formify.Business.Dtos.FormDtos;
using Formify.Business.Dtos.UserDtos;
using Formify.Domain.Entities;

namespace Formify.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Form, FormDto>().ReverseMap();
            CreateMap<Form, CreateFormDto>().ReverseMap();
            CreateMap<Field, FieldDto>().ReverseMap();
            CreateMap<Field, CreateFieldDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
        }
    }
}