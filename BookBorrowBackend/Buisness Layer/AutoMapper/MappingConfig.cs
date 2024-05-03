using AutoMapper;
using Buisness_Layer.Models;
using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.AutoMapper
{
    public class MappingConfig
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookModel, BookEntity>();
                cfg.CreateMap<BookEntity, BookModel>();
                cfg.CreateMap<UserEntity,UserModel>();
                //cfg.CreateMap<UserEntity, UserModel>().ForMember(dest=>dest.Books_Lent,opt=>opt.MapFrom(src=>src.Books_Lent.ToList())).ForMember(dest=>dest.Book_Borrowed,opt=>opt.MapFrom(src=>src.Book_Borrowed.ToList()));
                cfg.CreateMap<UserModel, UserEntity>();
               
            });

            return config.CreateMapper();
        }
    }
}
