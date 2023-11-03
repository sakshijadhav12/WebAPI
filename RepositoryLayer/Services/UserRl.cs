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
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using RepositoryLayer.Migrations;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

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
                userentity.EmailId = userResgistration.EmailId;
                userentity.Password = EncryptPass(userResgistration.Password);
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
            var encodePass = EncryptPass(userLogin.Password);
            UserEntity CheckIdAndPass= fundoDbContext.User.FirstOrDefault(x=>x.EmailId==userLogin.EmailId && x.Password==encodePass);
            if(CheckIdAndPass!=null)
            {
                 var token = GenerateToken(CheckIdAndPass.EmailId, CheckIdAndPass.User_Id);
                 return token;
               

            }
            else
            {
                return null;
            }
        }
        public UserEntity LoginSession(UserLogin userLogin)
        {
            try
            {
                var encodePass = EncryptPass(userLogin.Password);
                var result = fundoDbContext.User.FirstOrDefault(x => x.EmailId == userLogin.EmailId && x.Password == encodePass);
                if (result != null)
                {
                    return result;

                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public UserEntity EmailExicts(string EmailId)
        {
            try
            {
                var EmailExict = fundoDbContext.User.FirstOrDefault(x => x.EmailId == EmailId);
                return EmailExict;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public string EncryptPass(string password)
        {
            try
            {
                string msg = "";
                byte[] encode = new byte[password.Length];
                encode = Encoding.UTF8.GetBytes(password);
                msg = Convert.ToBase64String(encode);
                return msg;
            }
            catch(Exception)
            {
                throw;
            }
        }
        public string ForgetPassword(string EmailId)
        {
            try
            {
                var result = fundoDbContext.User.FirstOrDefault(x => x.EmailId == EmailId);
                if(result!=null) 
                {
                    var token = this.GenerateToken(result.EmailId, result.User_Id);
                    MSMQModel mSMQModel = new MSMQModel();
                    mSMQModel.SendMessage(token, result.EmailId, result.FirstName);
                    return token.ToString();

                }
                else
                {
                    return null;
                }
            }
            catch(Exception)
            {
                throw;
            }

        }
        public bool ResetPassword(string email,Resetpass reset)
        {
            
            try
            {    
                if(reset.Password.Equals(reset.ConfirmPassword))
                {   
                    var user = fundoDbContext.User.Where(x => x.EmailId == email).FirstOrDefault();
                    string encryptedPassword = EncryptPass(reset.ConfirmPassword);
                    user.Password = encryptedPassword;
                    fundoDbContext.SaveChanges();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception) 
            {
                throw;
            }
        }
        private string GenerateToken(string EmailId, int User_Id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Email", EmailId),
                        new Claim("User_Id", User_Id.ToString())
            };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public List<UserEntity> PrintUsers()
        {
            try
            {
                List<UserEntity> result = (List<UserEntity>)fundoDbContext.User.ToList();
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
       

    }
}

