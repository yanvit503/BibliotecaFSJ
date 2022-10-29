﻿// <auto-generated />
using System;
using BibliotecaFSJ.DAO.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BibliotecaFSJ.DAO.Migrations
{
    [DbContext(typeof(ContextoBanco))]
    [Migration("20221029175143_IdConversa")]
    partial class IdConversa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BibliotecaFSJ.Models.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdAutor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdTopico")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("BibliotecaFSJ.Models.Conversa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Conversas");
                });

            modelBuilder.Entity("BibliotecaFSJ.Models.Mensagem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Conteudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ConversaId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Envio")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdDestinatario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdRemetente")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConversaId");

                    b.ToTable("Mensagens");
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

            modelBuilder.Entity("BibliotecaFSJ.Models.Mensagem", b =>
                {
                    b.HasOne("BibliotecaFSJ.Models.Conversa", "Conversa")
                        .WithMany("Mensagens")
                        .HasForeignKey("ConversaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conversa");
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

            modelBuilder.Entity("BibliotecaFSJ.Models.Conversa", b =>
                {
                    b.Navigation("Mensagens");
                });

            modelBuilder.Entity("BibliotecaFSJ.Models.Topico", b =>
                {
                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
