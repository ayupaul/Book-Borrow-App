using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Models
{
    public class UserModel
    {
        public int? UserId { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? TokenAvailable { get; set; }
        public string? Token { get; set; }
        public List<BookModel> Books_Lent { get; set; } = new List<BookModel>();
        public List<BookModel> Book_Borrowed { get; set; } = new List<BookModel>();
    }
}
