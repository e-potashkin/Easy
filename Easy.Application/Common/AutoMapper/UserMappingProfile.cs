using AutoMapper;
using Easy.Application.Users.V1.Commands;
using Easy.Application.Users.V1.Responses;
using Easy.Domain.Entities;

namespace Easy.Application.Common.AutoMapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
        }
    }
}