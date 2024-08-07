using Application.Contracts.Base;
using Application.DTOs.Reply;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IReplyRepository: IRepositoryBase<int, Reply>
    {
        Task<List<GetReplyDto>> GetRepliesByCommentId(int commentId);
        Task DeleteReplyById(int id);
    }
}
