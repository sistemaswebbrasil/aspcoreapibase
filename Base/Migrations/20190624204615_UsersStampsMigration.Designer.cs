﻿// <auto-generated />
using System;
using Base.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Base.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190624204615_UsersStampsMigration")]
    partial class UsersStampsMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Base.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy")
                        .HasColumnName("created_by");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("varchar(80)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("datetime");

                    b.Property<int>("UpdatedBy")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("Base.Models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy")
                        .HasColumnName("created_by");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsComplete")
                        .HasColumnName("IsComplete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(80)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("datetime");

                    b.Property<int>("UpdatedBy")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.ToTable("todos");
                });

            modelBuilder.Entity("Base.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy")
                        .HasColumnName("created_by");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(254)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("varchar(60)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("datetime");

                    b.Property<int>("UpdatedBy")
                        .HasColumnName("updated_by");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username")
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("users_email_unique");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasName("users_username_unique");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
