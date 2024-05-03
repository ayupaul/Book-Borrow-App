using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class BookLentedAndUserMappingEntity
    {
        [Key]
        public int? Id { get; set; }
        public int? LentedUserId { get; set; }
        public UserEntity? LentedUser { get; set; }
        public int? Lented_BookId { get; set; }
        public BookEntity? Lented_Book { get; set; }
    }
}
