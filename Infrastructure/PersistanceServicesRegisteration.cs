using Domain.DboContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories;
using Application.Contracts;
using Application.DTOs.Users;
using Application.Validators;
using FluentValidation;

namespace Infrastructure
{
    public static class PersistanceServicesRegisteration
    {
        public static void ConfigurePersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ArianTestContext>(x => x.UseSqlServer(configuration.GetConnectionString("ArianConnectionString")));

            services.AddScoped<IUserRepository, UsersRepository>();
            services.AddScoped<IPostRepository, PostsRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IReplyRepository, ReplyRepository>();

            services.AddScoped<IValidator<CreateUserDto>, UserValidator>();

        }
    }
}
