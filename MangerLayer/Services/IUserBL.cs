using CommonLayer.Model;
using RepositoryLayer.Entity;

namespace MangerLayer.Services
{
    public interface IUserBL
    {
        UserEntity UserRegistration(UserRegstration userRegistration);
        public string Login(UserLogin userLogin);
    }
}