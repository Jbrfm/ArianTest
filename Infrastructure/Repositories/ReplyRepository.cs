using Application.Contracts;
using Application.DTOs.Reply;
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
    public class ReplyRepository : RepositoryBase<int, Reply>, IReplyRepository
    {
        private ArianTestContext _dboContext;
        private readonly IMapper _mapper;

        public ReplyRepository
            (
                ArianTestContext dboContext,
                IMapper mapper
            ) : base(dboContext)
        {
            _dboContext = dboContext;
            _mapper = mapper;
        }

        public async Task<List<GetReplyDto>> GetRepliesByCommentId(int commentId)
        {
            var result = await _dboContext.GetProcedures().GetRepliesByCommentIdAsync(commentId);

            var mapped = _mapper.Map<List<GetReplyDto>>(result);

            return mapped;
        }

        public async Task DeleteReplyById(int id)
        {
            await _dboContext.GetProcedures().DeleteReplyAsync(id);
        }
    }
}
