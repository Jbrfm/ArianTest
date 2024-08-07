using Application.Contracts.Base;
using Application.DTOs.Posts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IPostRepository : IRepositoryBase<int, Post>
    {
        Task<List<GetPostDto>> GetPostsByFilter(PostsFilterDto filter);
        Task DeletePostById(int postId);
    }
}
