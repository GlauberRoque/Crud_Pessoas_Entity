﻿// <auto-generated />
using AulaEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AulaEntity.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20211221234836_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AulaEntity.model.Email", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pessoaid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("pessoaid");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("AulaEntity.model.Pessoa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("AulaEntity.model.Email", b =>
                {
                    b.HasOne("AulaEntity.model.Pessoa", "pessoa")
                        .WithMany("Emails")
                        .HasForeignKey("pessoaid")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("pessoa");
                });

            modelBuilder.Entity("AulaEntity.model.Pessoa", b =>
                {
                    b.Navigation("Emails");
                });
#pragma warning restore 612, 618
        }
    }
}