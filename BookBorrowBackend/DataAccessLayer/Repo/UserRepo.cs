using DataAccessLayer.Db;
using DataAccessLayer.Entity;
using DataAccessLayer.IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext appDbContext;

        public UserRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task<UserEntity?> GetUserByIdAsync(int? id)
        {
            var user = await appDbContext.Users.FirstOrDefaultAsync(i => i.UserId == id);
            return user;
        }

        public async Task<UserEntity?> VerifyAsync(string username, string password)
        {
            var verify = await appDbContext.Users.FirstOrDefaultAsync(i => i.Username == username && i.Password == password);
            return verify;
        }
    }
}
