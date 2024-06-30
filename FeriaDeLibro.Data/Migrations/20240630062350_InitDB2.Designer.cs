﻿// <auto-generated />
using System;
using FeriaDeLibro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FeriaDeLibro.Data.Migrations
{
    [DbContext(typeof(FeriaDeLibroContext))]
    [Migration("20240630062350_InitDB2")]
    partial class InitDB2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FeriaDeLibro.Entities.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<DateOnly>("EventDate")
                        .HasColumnType("date")
                        .HasColumnName("Fecha");

                    b.Property<string>("EventDescription")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descripcion");

                    b.Property<TimeOnly>("EventTime")
                        .HasColumnType("time")
                        .HasColumnName("Hora");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Institute")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Instituto");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("FeriaDeLibro.Entities.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
