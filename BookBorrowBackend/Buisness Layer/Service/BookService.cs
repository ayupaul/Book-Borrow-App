using AutoMapper;
using Buisness_Layer.IService;
using Buisness_Layer.Models;
using DataAccessLayer.Db;
using DataAccessLayer.Entity;
using DataAccessLayer.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Service
{
    public class BookService : IBookService
    {
        private readonly IMapper mapper;
        private readonly IBookRepo bookRepo;

        public BookService(IMapper mapper, IBookRepo bookRepo)
        {
            this.mapper = mapper;
            this.bookRepo = bookRepo;
        }
        public async Task<string> AddBookAsync(int userId,BookEntity book)
        {
            
            var message = await bookRepo.AddBookAsync(userId,book);
            return message;
        }

        public async Task BorrowAsync(UserEntity borrower, BookEntity book, UserEntity lender, int userId, int bookId)
        {
           await bookRepo.BorrowAsync(borrower,book,lender,userId,bookId);
        }

        public async Task<List<BookModel>> GetAllAvailableBooksAsync()
        {
            var books = await bookRepo.GetAllAvailableBooksAsync();
            var booksModel = mapper.Map<List<BookModel>>(books);
            return booksModel;
        }

        public async Task<List<BookLentedAndUserMappingEntity>> GetAllBooksLentedByOthersAsync(int? userId)
        {
            var books = await bookRepo.GetAllBooksLentedByOthersAsync(userId);
            return books;
        }


        public async Task<BookEntity> GetBookByIdAsync(int? id)
        {
            var book = await bookRepo.GetBookByIdAsync(id);
            return book;
        }

        public async Task<List<BookBorrowedAndUserMappingEntity>> GetBorrowedBooksAsync(int? userId)
        {
            var borrowed_books=await bookRepo.GetBorrowedBooksAsync(userId);
            return borrowed_books;
        }

        public async Task<BookLentedAndUserMappingEntity?> GetLenderUserIdAsync(int? bookId)
        {
            return await bookRepo.GetLenderUserIdAsync(bookId);
        }

        public async Task<List<BookLentedAndUserMappingEntity>> GetLentedBooksAsync(int? userId)
        {
            var lented_books=await bookRepo.GetLentedBooksAsync(userId);
            return lented_books;
        }

    

        public async Task<List<BookModel>> SearchBooks(string word)
        {
            var books = await bookRepo.SearchBooks(word);
            var booksModel = mapper.Map<List<BookModel>>(books);
            return booksModel;
        }

        
    }
}
