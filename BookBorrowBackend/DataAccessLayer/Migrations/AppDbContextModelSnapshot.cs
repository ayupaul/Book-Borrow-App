﻿// <auto-generated />
using System;
using DataAccessLayer.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataAccessLayer.Entity.BookBorrowedAndUserMappingEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int?>("CurrentBorrowedByUserId")
                        .HasColumnType("int");

                    b.Property<int?>("Currently_Borrowed_BookId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrentBorrowedByUserId");

                    b.HasIndex("Currently_Borrowed_BookId");

                    b.ToTable("bookBorroweds");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.BookEntity", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"), 1L, 1);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsBookAvailable")
                        .HasColumnType("bit");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Author = "Joey",
                            BookName = "Friends",
                            Description = "Story of six friends",
                            Genre = "Comedy",
                            IsBookAvailable = true,
                            Rating = 5
                        },
                        new
                        {
                            BookId = 2,
                            Author = "Tony",
                            BookName = "Avengers",
                            Description = "Saving the world",
                            Genre = "Action",
                            IsBookAvailable = true,
                            Rating = 4
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Entity.BookLentedAndUserMappingEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int?>("LentedUserId")
                        .HasColumnType("int");

                    b.Property<int?>("Lented_BookId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LentedUserId");

                    b.HasIndex("Lented_BookId");

                    b.ToTable("bookLenteds");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            LentedUserId = 2,
                            Lented_BookId = 1
                        },
                        new
                        {
                            Id = 4,
                            LentedUserId = 2,
                            Lented_BookId = 2
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Entity.UserEntity", b =>
                {
                    b.Property<int?>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("UserId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TokenAvailable")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Name = "Ayush Pal",
                            Password = "Ayush123@",
                            TokenAvailable = 5,
                            Username = "ayush@gmail.com"
                        },
                        new
                        {
                            UserId = 2,
                            Name = "Abhishek Pal",
                            Password = "Abhishek123@",
                            TokenAvailable = 4,
                            Username = "abhishek@gmail.com"
                        },
                        new
                        {
                            UserId = 3,
                            Name = "User1",
                            Password = "User123@",
                            TokenAvailable = 4,
                            Username = "user1@gmail.com"
                        },
                        new
                        {
                            UserId = 4,
                            Name = "User2",
                            Password = "User2123@",
                            TokenAvailable = 4,
                            Username = "user2@gmail.com"
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Entity.BookBorrowedAndUserMappingEntity", b =>
                {
                    b.HasOne("DataAccessLayer.Entity.UserEntity", "CurrentBorrowedByUser")
                        .WithMany()
                        .HasForeignKey("CurrentBorrowedByUserId");

                    b.HasOne("DataAccessLayer.Entity.BookEntity", "Currently_Borrowed_Book")
                        .WithMany()
                        .HasForeignKey("Currently_Borrowed_BookId");

                    b.Navigation("CurrentBorrowedByUser");

                    b.Navigation("Currently_Borrowed_Book");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.BookLentedAndUserMappingEntity", b =>
                {
                    b.HasOne("DataAccessLayer.Entity.UserEntity", "LentedUser")
                        .WithMany()
                        .HasForeignKey("LentedUserId");

                    b.HasOne("DataAccessLayer.Entity.BookEntity", "Lented_Book")
                        .WithMany()
                        .HasForeignKey("Lented_BookId");

                    b.Navigation("LentedUser");

                    b.Navigation("Lented_Book");
                });
#pragma warning restore 612, 618
        }
    }
}
