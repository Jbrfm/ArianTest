using Application.Contracts;
using Application.DTOs.Comments;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArianTestOnion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentController
            (
                ICommentRepository commentRepository,
                IMapper mapper
            )
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        [HttpPost("GetCommentByFilter")]
        public async Task<IActionResult> GetCommentByFilter(CommentFilter filter)
        {
            var result = await _commentRepository.GetCommentsByFilter(filter);
            return Ok(result);
        }

        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment(CreateCommentDto comment)
        {
            //check user existance

            //check input validation

            var mapped = _mapper.Map<Comment>(comment);

            try
            {
                await _commentRepository.AddAsync(mapped);
                await _commentRepository.SaveChangesAsync();

                return Ok(1);
            }
            catch
            {
                return BadRequest("Coudn't.");
            }
        }

        [HttpDelete("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteCommentById(int id)
        {
            //check if comment exist
            try
            {
                await _commentRepository.DeleteCommentById(id);

                return Ok("Deleted.");
            }
            catch
            {
                return BadRequest("coudn't.");
            }
        }
    }
}
