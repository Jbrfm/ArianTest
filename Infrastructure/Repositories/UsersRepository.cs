using Application.Contracts;
using Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using AutoMapper;
using Domain.DboContext;
using Application.DTOs.Users;

namespace Infrastructure.Repositories
{
    public class UsersRepository : RepositoryBase<int, User>, IUserRepository
    {
        private ArianTestContext _dboContext;
        private readonly IMapper _mapper;

        public UsersRepository
            (
                ArianTestContext dboContext,
                IMapper mapper
            ) : base(dboContext)
        {
            _dboContext = dboContext;
            _mapper = mapper;
        }

        public async Task<GetUserDto> GetUserByUsername(string username)
        {
            var result = await _dboContext.GetProcedures().GetUserByUsernameAsync(username);

            var mapped = _mapper.Map<GetUserDto>(result.FirstOrDefault());

            return mapped;
        }

        public async Task DeleteUserById(int id)
        {
            await _dboContext.GetProcedures().DeleteUserAsync(id);
        }
    }
}
