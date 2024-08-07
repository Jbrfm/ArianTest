using Application.DTOs.Comments;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Profiles
{
    public class CommentMapper : Profile
    {
        public CommentMapper()
        {
            CreateMap<GetCommentsByFilterResult, GetCommentDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.comment_id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.user_id))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.post_id));

            CreateMap<CreateCommentDto, Comment>();
        }
    }
}
