﻿// <auto-generated />
using BibliotecaFSJ.DAO.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BibliotecaFSJ.DAO.Migrations
{
    [DbContext(typeof(ContextoBanco))]
    partial class ContextoBancoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BibiotecaFSJ.Models.Livro", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("BibliotecaFSJ.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Texto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TopicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TopicoId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("BibliotecaFSJ.Models.Topico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Texto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Topicos");
                });

            modelBuilder.Entity("BibliotecaFSJ.Models.TopicoImagens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TopicoId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TopicoId");

                    b.ToTable("TopicoImagens");
                });

            modelBuilder.Entity("BibliotecaFSJ.Models.Tag", b =>
                {
                    b.HasOne("BibliotecaFSJ.Models.Topico", "Topico")
                        .WithMany("Tags")
                        .HasForeignKey("TopicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topico");
                });

            modelBuilder.Entity("BibliotecaFSJ.Models.TopicoImagens", b =>
                {
                    b.HasOne("BibliotecaFSJ.Models.Topico", "Topico")
                        .WithMany()
                        .HasForeignKey("TopicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topico");
                });

            modelBuilder.Entity("BibliotecaFSJ.Models.Topico", b =>
                {
                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
