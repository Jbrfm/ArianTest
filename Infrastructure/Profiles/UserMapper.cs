using Application.DTOs.Users;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Profiles
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<GetUserDto, User>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));

            CreateMap<User, CreateUserDto>().ReverseMap();

            CreateMap<UpdateUserDto, User>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

            CreateMap<GetUserByUsernameResult, GetUserDto>().ReverseMap()
                .ForMember(dest => dest.user_id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
