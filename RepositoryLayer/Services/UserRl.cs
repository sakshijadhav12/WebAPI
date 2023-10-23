using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;
using RepositoryLayer.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace RepositoryLayer.Services
{
    public class UserRl:IUserRL
    {
        private readonly FundoDbContext fundoDbContext;
        private readonly IConfiguration configuration;

        public UserRl(FundoDbContext fundoDbContext, IConfiguration configuration)
        {
            this.fundoDbContext = fundoDbContext;
            this. configuration=configuration;
        }
        public UserEntity UserResgistrations(UserRegstration userResgistration)
        {
            try
            {
                UserEntity userentity = new  UserEntity();
                userentity.FirstName = userResgistration.FirstName;
                userentity.LastName = userResgistration.LastName;
                userentity.EmailId=userResgistration.EmailId;
                userentity.Password= userResgistration.Password;
                fundoDbContext.User.Add(userentity);
                int result = fundoDbContext.SaveChanges();
               if(result>0)
                {
                    return userentity;
                }
               else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                
               throw;
            }
        }

        public string Login(UserLogin userLogin) 
        { 
            UserEntity CheckIdAndPass= fundoDbContext.User.FirstOrDefault(x=>x.EmailId==userLogin.EmailId && x.Password==userLogin.Password);
            if(CheckIdAndPass!=null)
            {
                return "login is successfull";

            }
            else
            {
                return "login is not successfull";
            }
        }




    }
}
