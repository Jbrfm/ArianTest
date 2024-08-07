using Application.Contracts;
using Application.DTOs.Reply;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArianTestOnion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepliesRepository : ControllerBase
    {
        private readonly IReplyRepository _replyRepository;
        private readonly IMapper _mapper;
        public RepliesRepository
            (
                IReplyRepository replyRepository,
                IMapper mapper
            )
        {
            _replyRepository = replyRepository;
            _mapper = mapper;
        }

        [HttpPost("GetRepliesByCommentId")]
        public async Task<IActionResult> GetRepliesByCommentId(int commentId)
        {
            //check comment id existence

            var result = await _replyRepository.GetRepliesByCommentId(commentId);

            return Ok(result);
        }

        [HttpPost("CreateReply")]
        public async Task<IActionResult> CreateReply(CreateReplyDto reply)
        {
            var mapped = _mapper.Map<Reply>(reply);

            try
            {
                await _replyRepository.AddAsync(mapped);
                await _replyRepository.SaveChangesAsync();

                return Ok();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex);
                return BadRequest("Coudn't."+ex);
            }
        }

        [HttpDelete("DeleteReply/{id}")]
        public async Task<IActionResult> DeleteReply(int id)
        {
            //checke if reply exist
            try
            {
                await _replyRepository.DeleteReplyById(id);

                return Ok("Deleted.");
            }
            catch
            {
                return BadRequest("coudn't.");
            }
        }
    }
}
