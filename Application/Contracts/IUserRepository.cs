using Application.Contracts.Base;
using Application.DTOs.Users;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IUserRepository : IRepositoryBase<int, User>
    {
        Task<GetUserDto> GetUserByUsername(string username);
        Task DeleteUserById(int id);
    }
}
