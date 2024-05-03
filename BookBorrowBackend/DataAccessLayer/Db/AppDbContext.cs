using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Db
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<BookBorrowedAndUserMappingEntity> bookBorroweds { get; set; }
        public DbSet<BookLentedAndUserMappingEntity> bookLenteds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity { UserId = 1, Name = "Ayush Pal", Username = "ayush@gmail.com", Password = "Ayush123@", TokenAvailable = 5 }
                );
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity { UserId = 2, Name = "Abhishek Pal", Username = "abhishek@gmail.com", Password = "Abhishek123@", TokenAvailable = 4}
                );
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity { UserId = 3, Name = "User1", Username = "user1@gmail.com", Password = "User123@", TokenAvailable = 4 }
                );
            modelBuilder.Entity<UserEntity>().HasData(
               new UserEntity { UserId = 4, Name = "User2", Username = "user2@gmail.com", Password = "User2123@", TokenAvailable = 4 }
               );
            modelBuilder.Entity<BookEntity>().HasData(
                new BookEntity { BookId=1,BookName="Friends",Author="Joey",Rating=5,Genre="Comedy",Description="Story of six friends", IsBookAvailable = true}
                );
            modelBuilder.Entity<BookEntity>().HasData(
               new BookEntity { BookId = 2, BookName = "Avengers", Author = "Tony", Rating = 4, Genre = "Action", Description = "Saving the world", IsBookAvailable = true }
               );
            modelBuilder.Entity<BookLentedAndUserMappingEntity>().HasData(
               new BookLentedAndUserMappingEntity
               {
                   Id = 3,
                   LentedUserId = 2,
                   Lented_BookId = 1,
               });
            modelBuilder.Entity<BookLentedAndUserMappingEntity>().HasData(
            new BookLentedAndUserMappingEntity
            {
                Id = 4,
                LentedUserId = 2,
                Lented_BookId = 2,
            });
            //modelBuilder.Entity<BookEntity>()
            //   .HasOne(b => b.CurrentlyBorrowedByUser)
            //   .WithMany(u => u.Book_Borrowed)
            //   .HasForeignKey(b => b.CurrentlyBorrowedByUserId)
            //   .IsRequired(false);
        }
    }
}
