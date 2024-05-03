using Buisness_Layer.Models;
using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.IService
{
    public interface IUserService
    {
        Task<UserModel> VerifyAsync(UserModel user);
        Task<UserEntity> GetUserByIdAsync(int? id);


    }
}
