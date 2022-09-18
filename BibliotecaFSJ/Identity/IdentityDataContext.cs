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
            builder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=tcc;Integrated Security=True");
        }
    }
}
