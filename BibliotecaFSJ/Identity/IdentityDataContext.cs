using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaFSJ.Identity
{
    public class ContextoIdentity : IdentityDbContext<IdentityUser>
    {
        public ContextoIdentity()
        {

        }

        public ContextoIdentity(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=SQL8001.site4now.net;Database=db_a853b3_yanvit503;User Id=db_a853b3_yanvit503_admin;Password=s1n4ps#@;");
        }
    }
}
