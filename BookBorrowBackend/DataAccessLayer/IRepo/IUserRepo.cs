using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepo
{
    public interface IUserRepo
    {
        Task<UserEntity?> VerifyAsync(string username, string password);
        Task<UserEntity?> GetUserByIdAsync(int? id);
    }
}
