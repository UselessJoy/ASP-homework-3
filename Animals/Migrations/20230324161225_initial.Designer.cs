﻿// <auto-generated />
using System;
using Animals.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Animals.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230324161225_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Animals.Model.Entity.AnimalsTable", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("integer");

                    b.Property<int?>("CellId")
                        .HasColumnType("integer");

                    b.Property<int?>("FeedingId")
                        .HasColumnType("integer");

                    b.Property<int?>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CellId");

                    b.HasIndex("FeedingId")
                        .IsUnique();

                    b.ToTable("AnimalsExamples");
                });

            modelBuilder.Entity("Animals.Model.Entity.Cell", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<string>("Place")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cells");
                });

            modelBuilder.Entity("Animals.Model.Entity.Feeding", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("Time")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Feedings");
                });

            modelBuilder.Entity("Animals.Model.Entity.AnimalsTable", b =>
                {
                    b.HasOne("Animals.Model.Entity.Cell", "Cell")
                        .WithMany("Animals")
                        .HasForeignKey("CellId");

                    b.HasOne("Animals.Model.Entity.Feeding", "Feeding")
                        .WithOne("Animals")
                        .HasForeignKey("Animals.Model.Entity.AnimalsTable", "FeedingId");

                    b.Navigation("Cell");

                    b.Navigation("Feeding");
                });

            modelBuilder.Entity("Animals.Model.Entity.Cell", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("Animals.Model.Entity.Feeding", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}
