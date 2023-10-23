using CommonLayer.Model;
using MangerLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;

namespace FundoNoteApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBl;

        public UserController(IUserBL userBl)
        {
            this.userBl = userBl;
        }
        [HttpPost]
        [Route("register")]
        //httplocalhost/api/User/register
        public IActionResult Registration(UserRegstration userRegstration)
        {
            var result = this.userBl.UserRegistration(userRegstration);
            if (result != null)
            {
                return Ok(new ResponseModel<UserEntity> { Status = true, Message = "Register successfull", Data = result });
            }
            else
            {
                return BadRequest(new ResponseModel<UserEntity> { Status = false, Message = "Not successfull" });
            }

        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserLogin userLogin)
         { var result=this.userBl.Login(userLogin);
            if(result!=null)
            {
                return Ok(new ResponseModel<string> { Status = true , Message="login successfull",Data = result });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Not successfull" });
            }

        }

    }
}
