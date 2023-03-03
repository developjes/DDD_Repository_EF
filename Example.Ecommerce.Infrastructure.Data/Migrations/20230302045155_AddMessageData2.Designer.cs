﻿// <auto-generated />
using System;
using Example.Ecommerce.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Example.Ecommerce.Infrastructure.Data.Migrations
{
    [DbContext(typeof(EfContext))]
    [Migration("20230302045155_AddMessageData2")]
    partial class AddMessageData2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Example.Ecommerce.Domain.Entity.CategoryEntity", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryId")
                        .HasColumnOrder(1)
                        .HasComment("Id tabla");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateAt")
                        .HasComment("Fecha de creacion del registro");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Description")
                        .HasColumnOrder(3)
                        .HasComment("Descripcion de la categoria");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name")
                        .HasColumnOrder(2)
                        .HasComment("Nombre de la categoria");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Picture")
                        .HasColumnOrder(4)
                        .HasComment("imagen de la categoria");

                    b.Property<int?>("PlanId")
                        .HasColumnType("int")
                        .HasColumnName("PlanId")
                        .HasColumnOrder(6)
                        .HasComment("Id tabla foranea");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdateAt")
                        .HasComment("Fecha de actualizacion del registro");

                    b.Property<int>("_stateId")
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("StateId")
                        .HasColumnOrder(5)
                        .HasComment("Id tabla foranea");

                    b.HasKey("CategoryId");

                    b.HasIndex("PlanId");

                    b.HasIndex("_stateId");

                    b.ToTable("Category", "Parametrization");
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entity.MessageEntity", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Key")
                        .HasColumnOrder(1)
                        .HasComment("Key message");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateAt")
                        .HasComment("Fecha de creacion del registro");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description")
                        .HasColumnOrder(2)
                        .HasComment("Descripcion del mensaje");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdateAt")
                        .HasComment("Fecha de actualizacion del registro");

                    b.HasKey("Key");

                    b.ToTable("Message", "Parametrization");

                    b.HasData(
                        new
                        {
                            Key = "NOT_FOUND",
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Registro no encontrado"
                        },
                        new
                        {
                            Key = "INSERT_SUCCESS",
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Registro creado correctamente"
                        },
                        new
                        {
                            Key = "UPDATE_SUCCESS",
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Registro actualizado correctamente"
                        },
                        new
                        {
                            Key = "DELETE_SUCCESS",
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Registro eliminado correctamente"
                        },
                        new
                        {
                            Key = "DELETE_ERROR",
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Registro no pudo ser eliminado"
                        },
                        new
                        {
                            Key = "INSERT_ERROR",
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Registro no pudo ser correctamente"
                        });
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entity.MovieCategoryEntity", b =>
                {
                    b.Property<int>("MovieCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MovieCategoryId")
                        .HasColumnOrder(1)
                        .HasComment("Id tabla");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieCategoryId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryId")
                        .HasColumnOrder(3)
                        .HasComment("Id tabla foranea");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateAt")
                        .HasComment("Fecha de creacion del registro");

                    b.Property<int>("MovieId")
                        .HasColumnType("int")
                        .HasColumnName("MovieId")
                        .HasColumnOrder(2)
                        .HasComment("Id tabla foranea");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdateAt")
                        .HasComment("Fecha de actualizacion del registro");

                    b.HasKey("MovieCategoryId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieCategory", "Parametrization");
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entity.MovieEntity", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MovieId")
                        .HasColumnOrder(1)
                        .HasComment("Id tabla");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"), 1L, 1);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateAt")
                        .HasComment("Fecha de creacion del registro");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Description")
                        .HasColumnOrder(3)
                        .HasComment("Descripcion de la categoria");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name")
                        .HasColumnOrder(2)
                        .HasComment("Nombre de la categoria");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdateAt")
                        .HasComment("Fecha de actualizacion del registro");

                    b.HasKey("MovieId");

                    b.ToTable("Movie", "Parametrization");
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entity.PlanEntity", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PlanId")
                        .HasColumnOrder(1)
                        .HasComment("Id tabla");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlanId"), 1L, 1);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateAt")
                        .HasComment("Fecha de creacion del registro");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name")
                        .HasColumnOrder(2)
                        .HasComment("Nombre del plan");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdateAt")
                        .HasComment("Fecha de actualizacion del registro");

                    b.HasKey("PlanId");

                    b.ToTable("Plan", "Parametrization");
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entity.StateEntity", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StateId")
                        .HasColumnOrder(1)
                        .HasComment("Id tabla");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateId"), 1L, 1);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateAt")
                        .HasComment("Fecha de creacion del registro");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Description")
                        .HasColumnOrder(3)
                        .HasComment("Descripcion del estado");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Name")
                        .HasColumnOrder(2)
                        .HasComment("Nombre del estado");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdateAt")
                        .HasComment("Fecha de actualizacion del registro");

                    b.HasKey("StateId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("State", "Parametrization");

                    b.HasData(
                        new
                        {
                            StateId = 1,
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Estado Activo",
                            Name = "Activo"
                        },
                        new
                        {
                            StateId = 2,
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Estado Inactivo",
                            Name = "Inactivo"
                        },
                        new
                        {
                            StateId = 4,
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Estado Restaurado",
                            Name = "Restaurado"
                        },
                        new
                        {
                            StateId = 3,
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Estado Expirado",
                            Name = "Expirado"
                        });
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entity.CategoryEntity", b =>
                {
                    b.HasOne("Example.Ecommerce.Domain.Entity.PlanEntity", "Plan")
                        .WithMany("Categories")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Example.Ecommerce.Domain.Entity.StateEntity", "State")
                        .WithMany("Categories")
                        .HasForeignKey("_stateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Plan");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entity.MovieCategoryEntity", b =>
                {
                    b.HasOne("Example.Ecommerce.Domain.Entity.CategoryEntity", "Category")
                        .WithMany("MoviesCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Example.Ecommerce.Domain.Entity.MovieEntity", "Movie")
                        .WithMany("MoviesCategories")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entity.CategoryEntity", b =>
                {
                    b.Navigation("MoviesCategories");
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entity.MovieEntity", b =>
                {
                    b.Navigation("MoviesCategories");
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entity.PlanEntity", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Example.Ecommerce.Domain.Entity.StateEntity", b =>
                {
                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
