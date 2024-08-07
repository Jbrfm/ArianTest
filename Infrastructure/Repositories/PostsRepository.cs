using Application.Contracts;
using Application.DTOs.Posts;
using AutoMapper;
using Domain.DboContext;
using Domain.Entities;
using Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostsRepository : RepositoryBase<int, Post>, IPostRepository
    {
        private ArianTestContext _dboContext;
        private readonly IMapper _mapper;

        public PostsRepository
            (
                ArianTestContext dboContext,
                IMapper mapper
            ) : base(dboContext)
        {
            _dboContext = dboContext;
            _mapper = mapper;
        }

        public async Task<List<GetPostDto>> GetPostsByFilter(PostsFilterDto filter)
        {
            var result = await _dboContext.GetProcedures().GetPostsByFilterAsync(
                filter.PostId == null ? -1 : filter.PostId,
                filter.Title == null ? "-1" : filter.Title,
                filter.UserId == null ? -1 : filter.UserId,
                filter.Username == null ? "-1" : filter.Username
            );

            var mapped = _mapper.Map<List<GetPostDto>>(result);

            return mapped;
        }

        public async Task DeletePostById(int postId)
        {
            await _dboContext.GetProcedures().DeletePostAsync(postId);
        }
    }
}
