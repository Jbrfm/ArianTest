using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Identity
{
    public class ArianIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public ArianIdentityDbContext(DbContextOptions<ArianIdentityDbContext> options)
            : base(options)
        {
        }
    }
}
