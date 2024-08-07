using Application.DTOs.Posts;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Profiles
{
    public class PostMapper : Profile
    {
        public PostMapper()
        {
            CreateMap<GetPostsByFilterResult, GetPostDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.post_id))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.user_id));

            CreateMap<CreatePostDto, Post>().ReverseMap();
        }
    }
}
