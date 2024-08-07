using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Identity;

namespace ViraTech.Datis.Identity
{
    public static class IdentityServicesRegisteration
    {
        public static void ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ArianIdentityDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ArianConnectionString")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ArianIdentityDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
