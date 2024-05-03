using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entity
{
    public class UserEntity
    {
        [Key]
        public int? UserId { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? TokenAvailable { get; set; }
        
        //public List<BookEntity> Books_Lent { get; set; }=new List<BookEntity>();
        //public List<BookEntity> Book_Borrowed { get; set; } = new List<BookEntity>();
    }
}
