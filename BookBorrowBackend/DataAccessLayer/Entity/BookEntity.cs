using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text.Json.Serialization;

namespace DataAccessLayer.Entity
{
    public class BookEntity
    {
        [Key]
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public int? Rating { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public bool? IsBookAvailable { get; set; }
        public string? Description { get; set; }
     
        //public int? LentByUserId { get; set; }
        //public UserEntity? LentByUser { get; set; }
     
        //public int? CurrentlyBorrowedByUserId { get; set; }
        //public UserEntity? CurrentlyBorrowedByUser { get; set; }











    }
}
