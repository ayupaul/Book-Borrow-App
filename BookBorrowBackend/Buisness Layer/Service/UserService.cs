using AutoMapper;
using Buisness_Layer.IService;
using Buisness_Layer.Models;
using DataAccessLayer.Entity;
using DataAccessLayer.IRepo;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepo userRepo;
        private readonly IMapper mapper;

        public UserService(IUserRepo userRepo, IMapper mapper)
        {
            this.userRepo = userRepo;
            this.mapper = mapper;
        }


        public async Task<UserEntity> GetUserByIdAsync(int? id)
        {
            var user = await userRepo.GetUserByIdAsync(id);
            return user;
        }

        public async Task<UserModel?> VerifyAsync(UserModel user)
        {
            var username = user.Username;
            var password = user.Password;
            var verify = await userRepo.VerifyAsync(username, password);

            if (verify == null)
            {
                return null;
            }
            else
            {
                var token = CreateJwt(verify);
                user.Token = token;
                return user;
            }

        }

        private string CreateJwt(UserEntity user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysecret.....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim("UserId",user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim("TokenAvailable",user.TokenAvailable.ToString())
            });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
