using CommonLayer.Model;
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
    }
}
