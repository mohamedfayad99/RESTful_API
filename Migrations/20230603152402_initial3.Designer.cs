﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rstfulapi.Models;

#nullable disable

namespace Rstfulapi.Migrations
{
    [DbContext(typeof(Applicationdb))]
    [Migration("20230603152402_initial3")]
    partial class initial3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Rstfulapi.Models.Villa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("id");

                    b.ToTable("villas");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Name = "Mohamed"
                        },
                        new
                        {
                            id = 2,
                            Name = "Ali"
                        },
                        new
                        {
                            id = 3,
                            Name = "Kedr"
                        },
                        new
                        {
                            id = 4,
                            Name = "Samir"
                        },
                        new
                        {
                            id = 5,
                            Name = "fady"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}