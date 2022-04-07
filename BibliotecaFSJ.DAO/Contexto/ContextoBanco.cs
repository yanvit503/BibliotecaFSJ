using BibliotecaFSJ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

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
            builder.UseSqlServer("Server=SQL8001.site4now.net;Database=db_a853b3_yanvit503;User Id=db_a853b3_yanvit503_admin;Password=s1n4ps#@;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
