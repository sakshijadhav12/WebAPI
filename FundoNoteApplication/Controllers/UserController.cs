using CommonLayer.Model;
using MangerLayer.Interfaces;
using MangerLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryLayer.Entity;
using System.Collections.Generic;
using System.Linq;

namespace FundoNoteApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBl;
        private readonly ILogger<UserController> logger;

        public UserController(IUserBL userBl ,ILogger<UserController> logger)
        {
            this.userBl = userBl;
            this.logger = logger;
        }
        [HttpPost]
        [Route("register")]
        //httplocalhost/api/User/register
        public IActionResult Registration(UserRegstration userRegstration)
        {
            logger.LogInformation("Registration Started");
            var result = this.userBl.UserRegistration(userRegstration);
            if (result != null)
            {
                logger.LogInformation("Registration Successfull");
                return Ok(new ResponseModel<UserEntity> { Status = true, Message = "Register successfull", Data = result });
            }
            else
            {
                logger.LogError("registration is not done successfully");
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
        [HttpPost]
        [Route("forgetPassword")]
        public IActionResult ForgetPassword(string EmailId)
        { 
            var result = this.userBl.ForgetPassword(EmailId); ;
            if (result != null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "successfull", Data = result });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Not successfull" });
            }

        }
        [Authorize]
        [HttpPost]
        [Route("resetPassword")]
        public IActionResult ResetPassword(Resetpass password)
        {
            string email = User.Claims.FirstOrDefault(x => x.Type == "Email").Value;
            var result = this.userBl.ResetPassword(email ,password);
            if(result != null)
            {
                return Ok(new ResponseModel<bool> { Status = true, Message = "successfull", Data = result });

            }
            else
            {
                return BadRequest(new ResponseModel<bool> { Status = false, Message = "Not successfull" });
            }


        }

        [HttpPost]
        [Route("Emailexicts")]
        public IActionResult EmailExicts(string EmailId)
        {
            var result = userBl.EmailExicts(EmailId);
            if (result!=null)
            {
                return Ok(new ResponseModel<UserEntity> { Status = true , Message="Email Exicts",Data = result });
            }
            else
            {
                return BadRequest(new ResponseModel<UserEntity> { Status = false, Message = "Not Exicts" });
            }
        }

        [HttpPost]
        [Route("printusers")]
        public IActionResult PrintUsers()
        {
            var result = userBl.PrintUsers();
            if (result != null)
            {
                return Ok(new ResponseModel<List<UserEntity>> { Status = true, Message = "successfull", Data = result });
            }
            else
            {
                return BadRequest(new ResponseModel<List<UserEntity>>{ Status = false, Message = "Not successfull" });
            }
        }

        [HttpPost]
        [Route("Session Login")]
        public IActionResult SessionLogin(UserLogin userLogin)
        {
           
            var result = this.userBl.LoginSession(userLogin);
            HttpContext.Session.SetInt32("UserID", result.User_Id);

            if (result != null)
            {
                return Ok(new ResponseModel<UserEntity> { Status = true, Message = "login successfull", Data = result });
            }
            else
            {
                return BadRequest(new ResponseModel<UserEntity> { Status = false, Message = "Not successfull" });
            }

        }
    }


    }
