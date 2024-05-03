using Buisness_Layer.Models;
using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.IService
{
    public interface IBookService
    {
        Task<string> AddBookAsync(int userId,BookEntity book);
        Task<List<BookModel>> GetAllAvailableBooksAsync();
        Task<BookEntity> GetBookByIdAsync(int? id);
  
        Task<List<BookModel>> SearchBooks(string word);
        Task<BookLentedAndUserMappingEntity?> GetLenderUserIdAsync(int? bookId);
        Task<List<BookLentedAndUserMappingEntity>> GetLentedBooksAsync(int? userId);
        Task<List<BookBorrowedAndUserMappingEntity>> GetBorrowedBooksAsync(int? userId);
        Task<List<BookLentedAndUserMappingEntity>> GetAllBooksLentedByOthersAsync(int? userId);
        Task BorrowAsync(UserEntity borrower, BookEntity book, UserEntity lender, int userId, int bookId);
       
    }
}
