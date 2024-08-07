using Application.Contracts.Base;
using Application.DTOs.Comments;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ICommentRepository : IRepositoryBase<int, Comment>
    {
        Task<List<GetCommentDto>> GetCommentsByFilter(CommentFilter filter);
        Task DeleteCommentById(int commentId);
    }
}
