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

    }
}
