﻿using BibiotecaFSJ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaFSJ.Configuracao
{
    public class ContextoBanco : DbContext
    {
        public DbSet<Livro> Livros { get; set; }

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