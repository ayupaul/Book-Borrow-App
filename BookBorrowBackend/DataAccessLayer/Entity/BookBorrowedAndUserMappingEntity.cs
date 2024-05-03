using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class BookBorrowedAndUserMappingEntity
    {
        [Key]
        public int? Id { get; set; }
        public int? CurrentBorrowedByUserId { get; set; }
        public UserEntity? CurrentBorrowedByUser { get; set; }

        public int? Currently_Borrowed_BookId { get; set; }
        public BookEntity? Currently_Borrowed_Book { get; set; }
    }
}
