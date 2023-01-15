﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stiri.Data;

#nullable disable

namespace Stiri.Migrations
{
    [DbContext(typeof(StiriContext))]
    [Migration("20230108145741_categorii_plus_plus")]
    partial class categorii_plus_plus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Stiri.Models.Articol", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("Aprobat")
                        .HasColumnType("bit");

                    b.Property<int>("CategorieID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("JurnalistID")
                        .HasColumnType("int");

                    b.Property<string>("Text_Articol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titlu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CategorieID");

                    b.HasIndex("JurnalistID");

                    b.ToTable("Articol");
                });

            modelBuilder.Entity("Stiri.Models.Articole_Jurnalist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("ArticolID")
                        .HasColumnType("int");

                    b.Property<int>("JurnalistID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ArticolID");

                    b.HasIndex("JurnalistID");

                    b.ToTable("Articole_Jurnalist");
                });

            modelBuilder.Entity("Stiri.Models.Categorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nume_Categorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("Stiri.Models.Categorii_Articole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("ArticolID")
                        .HasColumnType("int");

                    b.Property<int>("CategorieID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ArticolID");

                    b.HasIndex("CategorieID");

                    b.ToTable("Categorii_Articole");
                });

            modelBuilder.Entity("Stiri.Models.Cititor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Cititor");
                });

            modelBuilder.Entity("Stiri.Models.Jurnalist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Jurnalist");
                });

            modelBuilder.Entity("Stiri.Models.Articol", b =>
                {
                    b.HasOne("Stiri.Models.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stiri.Models.Jurnalist", "Jurnalist")
                        .WithMany()
                        .HasForeignKey("JurnalistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Jurnalist");
                });

            modelBuilder.Entity("Stiri.Models.Articole_Jurnalist", b =>
                {
                    b.HasOne("Stiri.Models.Articol", "Articole")
                        .WithMany()
                        .HasForeignKey("ArticolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stiri.Models.Jurnalist", null)
                        .WithMany("Articole_Jurnalist")
                        .HasForeignKey("JurnalistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articole");
                });

            modelBuilder.Entity("Stiri.Models.Categorii_Articole", b =>
                {
                    b.HasOne("Stiri.Models.Articol", "Articole")
                        .WithMany("Categorii_Articole")
                        .HasForeignKey("ArticolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stiri.Models.Categorie", null)
                        .WithMany("Categorii_Articole")
                        .HasForeignKey("CategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articole");
                });

            modelBuilder.Entity("Stiri.Models.Articol", b =>
                {
                    b.Navigation("Categorii_Articole");
                });

            modelBuilder.Entity("Stiri.Models.Categorie", b =>
                {
                    b.Navigation("Categorii_Articole");
                });

            modelBuilder.Entity("Stiri.Models.Jurnalist", b =>
                {
                    b.Navigation("Articole_Jurnalist");
                });
#pragma warning restore 612, 618
        }
    }
}
