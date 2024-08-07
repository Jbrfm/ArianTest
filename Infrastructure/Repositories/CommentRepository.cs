using Application.Contracts;
using Application.DTOs.Comments;
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
    public class CommentRepository : RepositoryBase<int, Comment>, ICommentRepository
    {
        private ArianTestContext _dboContext;
        private readonly IMapper _mapper;

        public CommentRepository
            (
                ArianTestContext dboContext,
                IMapper mapper
            ) : base(dboContext)
        {
            _dboContext = dboContext;
            _mapper = mapper;
        }

        public async Task<List<GetCommentDto>> GetCommentsByFilter(CommentFilter filter)
        {
            //delete replies

            //delete comment
            var result = await _dboContext.GetProcedures().GetCommentsByFilterAsync(
                filter.CommentId == 0 ? -1 : filter.CommentId,
                filter.PostId == 0 ? -1 : filter.PostId,
                filter.UserId == 0 ? -1 : filter.UserId
            );
            var mapped = _mapper.Map<List<GetCommentDto>>(result);

            return mapped;
        }

        public async Task DeleteCommentById(int commentId)
        {
            await _dboContext.GetProcedures().DeleteCommentAsync(commentId);
        }
    }
}
