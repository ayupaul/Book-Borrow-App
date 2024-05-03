using Buisness_Layer.IService;
using Buisness_Layer.Models;
using DataAccessLayer.Db;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookBorrowBackend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class BookController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IBookService bookService;
        private readonly IUserService userService;

        public BookController(AppDbContext appDbContext, IBookService bookService, IUserService userService)
        {
            _appDbContext = appDbContext;
            this.bookService = bookService;
            this.userService = userService;
        }
        [HttpPost("addBook/{userId}")]
        public async Task<IActionResult> AddBook([FromRoute] int userId,BookEntity book)
        {
            if (book == null)
            {
                return BadRequest();
            }
          
            var message=await bookService.AddBookAsync(userId, book);
            return Ok(new
            {
                Message = message
            }) ;
        }
        [HttpGet("getAvaiableBooks")]
  
        public async Task<IActionResult> GetAvailableBooks()
        {
           
            var books = await bookService.GetAllAvailableBooksAsync();
            return Ok(books);
        }
        [HttpGet("getBookById/{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
           
            var book = await bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost("borrow/{bookId}")]
      
        public async Task<IActionResult> Borrow([FromRoute] int bookId, [FromBody] UserEntity payload)
        {
          
            var bookid = bookId;
            var userId = payload.UserId;
       
            var book=await bookService.GetBookByIdAsync(bookid);
           
            var user=await userService.GetUserByIdAsync(userId);
            book.IsBookAvailable = false;
           
            var getLenderUserId=await bookService.GetLenderUserIdAsync(bookId);
      
            var lender = await userService.GetUserByIdAsync(getLenderUserId.LentedUserId);
          
            var borrower = await userService.GetUserByIdAsync(userId);
            await bookService.BorrowAsync(borrower, book, lender, (int)payload.UserId, bookId);
          
            return Ok(new { Message = "Book Borrowed Successfully", availableToken = borrower.TokenAvailable });
        }
        [HttpGet("getBookLent/{userId}")]
        public async Task<IActionResult> GetBookLent([FromRoute] int userId)
        {
            if (userId == 0)
            {
                return BadRequest();
            }
         
            var lented_books=await bookService.GetLentedBooksAsync(userId);
            return Ok(lented_books);
        
        }

        [HttpGet("getBookBorrowed/{userId}")]
       
        public async Task<IActionResult> GetBookBorrowed([FromRoute] int userId)
        {
            if (userId == 0)
            {
                return BadRequest();
            }
           
            var booksBorrowed=await bookService.GetBorrowedBooksAsync(userId);
            return Ok(booksBorrowed);
        }
        [HttpGet("getAllBooksAddedByOthers/{userId}")]

        public async Task<IActionResult> GetAllBooksAddedByOthers([FromRoute] int userId)
        {
            if (userId == 0)
            {
                return BadRequest();
            }
            
            var lented_books=await bookService.GetAllBooksLentedByOthersAsync(userId);
            return Ok(lented_books);
        }
        [HttpGet("search/{word}")]

        public async Task<IActionResult> Search([FromRoute] string word)
        {

            word = word.ToLower();
           
            var matchingBooks = await bookService.SearchBooks(word);
            return Ok(matchingBooks);
        }
        [HttpGet("getLenderUserId/{bookId}")]
        public async Task<IActionResult> GetLenderUserId([FromRoute] int bookId)
        {
            if(bookId== 0)
            {
                return BadRequest();
            }
          
            var bookAndUser = await bookService.GetLenderUserIdAsync(bookId);
            return Ok(bookAndUser.LentedUserId);
        }
    }
}
