using BibliotecaFSJ.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaFSJ.DAO.Contexto
{
    public class ContextoBanco : DbContext
    {
        public DbSet<Topico> Topicos { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<TopicoImagens> TopicoImagens { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        public ContextoBanco() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=tcc;Integrated Security=True");
        }
    }
}