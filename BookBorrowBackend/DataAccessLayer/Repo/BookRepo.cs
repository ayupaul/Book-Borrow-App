using DataAccessLayer.Db;
using DataAccessLayer.Entity;
using DataAccessLayer.IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public class BookRepo : IBookRepo
    {
        private readonly AppDbContext appDbContext;

        public BookRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<string> AddBookAsync(int userId,BookEntity book)
        {
            book.IsBookAvailable = true;
            await appDbContext.Books.AddAsync(book);
            await appDbContext.SaveChangesAsync();
            var bookId = book.BookId;
            BookLentedAndUserMappingEntity lentedEntity = new BookLentedAndUserMappingEntity();
            lentedEntity.Lented_BookId = bookId;
            lentedEntity.LentedUserId = userId;
            await appDbContext.bookLenteds.AddRangeAsync(lentedEntity);
            await appDbContext.SaveChangesAsync();
            return "Book Added Successfully";
        }

        public async Task BorrowAsync(UserEntity borrower, BookEntity book,UserEntity lender,int userId,int bookId)
        {
            if (borrower.TokenAvailable > 0)
            {
                borrower.TokenAvailable -= 1;
                lender.TokenAvailable += 1;
                BookBorrowedAndUserMappingEntity borrowedEntity = new BookBorrowedAndUserMappingEntity();
                borrowedEntity.CurrentBorrowedByUserId = userId;
                borrowedEntity.Currently_Borrowed_BookId = bookId;
                appDbContext.Entry(book).State = EntityState.Modified;
                await appDbContext.bookBorroweds.AddAsync(borrowedEntity);
                await appDbContext.SaveChangesAsync();
            }

           
        }

        public async Task<List<BookEntity>> GetAllAvailableBooksAsync()
        {
            var books = await appDbContext.Books.Where(i => i.IsBookAvailable == true).ToListAsync();
            return books;
        }

        public async Task<List<BookLentedAndUserMappingEntity>> GetAllBooksLentedByOthersAsync(int? userId)
        {
            var lented_books = await appDbContext.bookLenteds.Include(u => u.Lented_Book).Where(i => i.LentedUserId != userId).ToListAsync();
            return lented_books;
        }


        public async Task<BookEntity?> GetBookByIdAsync(int? id)
        {
            var book = await appDbContext.Books.FirstOrDefaultAsync(i => i.BookId == id);
            return book;
        }

        public async Task<List<BookBorrowedAndUserMappingEntity>> GetBorrowedBooksAsync(int? userId)
        {
            var booksBorrowed = await appDbContext.bookBorroweds.Include(u => u.Currently_Borrowed_Book).Where(i => i.CurrentBorrowedByUserId == userId).ToListAsync();
            return booksBorrowed;
        }

        public async Task<BookLentedAndUserMappingEntity?> GetLenderUserIdAsync(int? bookId)
        {
            var getLenderUserId = await appDbContext.bookLenteds.FirstOrDefaultAsync(u => u.Lented_BookId == bookId);
            return getLenderUserId;
        }

        public async Task<List<BookLentedAndUserMappingEntity>> GetLentedBooksAsync(int? userId)
        {
            var lented_books = await appDbContext.bookLenteds.Include(u => u.Lented_Book).Where(i => i.LentedUserId == userId).ToListAsync();
            return lented_books;
        }

      

        public async Task<List<BookEntity>> SearchBooks(string word)
        {
            var matchingBooks = await appDbContext.Books.Where(i => i.BookName.ToLower() == word || i.Genre.ToLower() == word || i.Author.ToLower() == word).ToListAsync();
            return matchingBooks;
        }

       

    }
}
