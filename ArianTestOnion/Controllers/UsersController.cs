using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Contracts;
using Domain.Entities;
using AutoMapper;
using Application.DTOs.Users;
using FluentValidation;

namespace ArianTestOnion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _usersRepository;
        private readonly IMapper _mapper;
        public UsersController
            (
                IUserRepository usersRepository,
                IMapper mapper
            )
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _usersRepository.GetAllAsync();

            var mapped = _mapper.Map<List<GetUserDto>>(result.ToList());

            return Ok(mapped);
        }

        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUsers(int id)
        {
            var result = await _usersRepository.GetAsync(id);

            var mapped = _mapper.Map<GetUserDto>(result);

            return Ok(mapped);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserDto user)
        {
            if (await _usersRepository.GetUserByUsername(user.Username) != null)
            {
                return BadRequest("This Username already exist.");
            }

            var mapped = _mapper.Map<User>(user);

            {
                try
                {
                    await _usersRepository.AddAsync(mapped);
                    await _usersRepository.SaveChangesAsync();

                    return Ok(1);
                }
                catch
                {
                    return BadRequest("Coudn't.");
                }
            }

        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserDto user)
        {
            if (!(await _usersRepository.Exists(user.Id)))
            {
                return NotFound("User with this id does not exist");
            }

            var mapped = _mapper.Map<User>(user);

            try
            {
                await _usersRepository.UpdateAsync(mapped);
                await _usersRepository.SaveChangesAsync();
                //await _usersRepository.UpdateUser(user);

                return Ok();
            }
            catch
            {
                return BadRequest("Coudn't.");
            }
        }

        [HttpDelete("DeleteUser/{Id}")]
        public async Task<IActionResult> DeleteUser(int Id)
        {

            if (!(await _usersRepository.Exists(Id)))
            {
                return NotFound("User with this id does not exist");
            }

            try
            {
                await _usersRepository.DeleteUserById(Id);

                return Ok("Deleted.");
            }
            catch
            {
                return BadRequest("coudn't.");
            }
        }
    }
}
