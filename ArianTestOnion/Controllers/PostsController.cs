using Application.Contracts;
using Application.DTOs.Posts;
using Application.DTOs.Users;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArianTestOnion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postsRepository;
        private readonly IMapper _mapper;
        public PostsController
            (
                IPostRepository postsRepository,
                IMapper mapper
            )
        {
            _postsRepository = postsRepository;
            _mapper = mapper;
        }

        [HttpPost("GetPostsByFilter")]
        public async Task<IActionResult> GetPostsByFilter(PostsFilterDto filter)
        {
            var result = await _postsRepository.GetPostsByFilter(filter);

            return Ok(result);
        }

        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost(CreatePostDto post)
        {
            //check user existance

            //check input validation

            var mapped = _mapper.Map<Post>(post);

            try
            {
                await _postsRepository.AddAsync(mapped);
                await _postsRepository.SaveChangesAsync();

                return Ok(1);
            }
            catch
            {
                return BadRequest("Coudn't.");
            }
        }

        [HttpDelete("DeletePost/{id}")]
        public async Task<IActionResult> DeletePostById(int id)
        {
            //check if post exist

            try
            {
                await _postsRepository.DeletePostById(id);
                return Ok("Deleted.");
            }
            catch
            {
                return BadRequest("coudn't.");
            }
        }
    }
}
