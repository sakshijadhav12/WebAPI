using CommonLayer.Model;
using MangerLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MangerLayer.Services
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userInterface;
        public UserBL(IUserRL userInterface)
        {
            this.userInterface = userInterface;
        }


        public UserEntity UserRegistration(UserRegstration userRegistration)
        {
            try
            {
                return this.userInterface.UserResgistrations(userRegistration);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Login(UserLogin userLogin)
        {
            try
            {
                return this.userInterface.Login(userLogin);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ForgetPassword(string EmailId)
        {
            try
            {
                return this.userInterface.ForgetPassword(EmailId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ResetPassword(string email, Resetpass reset)
        {
            try
            {
                return this.userInterface.ResetPassword(email, reset);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserEntity EmailExicts(string EmailId)
        {
            try
            {
                return this.userInterface.EmailExicts(EmailId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<UserEntity> PrintUsers()
        {
            try
            {
               return this.userInterface.PrintUsers();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public UserEntity LoginSession(UserLogin userLogin)
        {
            try
            {
                return this.userInterface.LoginSession(userLogin);
            }
            catch(Exception ex)
            {
                throw;
            }
        }


    }
}
