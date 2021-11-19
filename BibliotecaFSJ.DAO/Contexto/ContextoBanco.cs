using BibiotecaFSJ.Models;
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
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Topico> Topicos { get; set; }

        public ContextoBanco() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=66.45.233.11;Database=bibliotecafsj;User Id=sysdba;Password=masterKEY123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
