using CommonLayer.Model;
using RepositoryLayer.Entity;
using System.Collections.Generic;

namespace MangerLayer.Services
{
    public interface IUserBL
    {
        UserEntity UserRegistration(UserRegstration userRegistration);
        public string Login(UserLogin userLogin);
        public string ForgetPassword(string EmailId);
        public bool ResetPassword(string email, Resetpass reset);
        public UserEntity EmailExicts(string EmailId);
        public List<UserEntity> PrintUsers();
    }
}