using Application.DTOs.Reply;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Profiles
{
    public class ReplyMapper : Profile
    {
        public ReplyMapper()
        {
            CreateMap<GetRepliesByCommentIdResult, GetReplyDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.reply_id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.user_id))
                .ForMember(dest => dest.CommentId, opt => opt.MapFrom(src => src.comment_id));

            CreateMap<CreateReplyDto, Reply>();
        }
    }
}
