using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRL
    {
        public UserEntity UserResgistrations(UserRegstration userResgistration);
        public string Login(UserLogin userLogin);
        public string ForgetPassword(string EmailId);
        public bool ResetPassword(string email, Resetpass reset);
        public UserEntity EmailExicts(string EmailId);
        public List<UserEntity> PrintUsers();
        public UserEntity LoginSession(UserLogin userLogin);
    }
}
