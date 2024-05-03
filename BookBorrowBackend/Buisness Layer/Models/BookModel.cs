using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public int? Rating { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public bool? IsBookAvailable { get; set; }
        public string? Description { get; set; }
        public int? LentByUserId { get; set; }
        public BookModel? LentByUser { get; set; }

        public int? CurrentlyBorrowedByUserId { get; set; }
        public BookModel? CurrentlyBorrowedByUser { get; set; }
    }
}
