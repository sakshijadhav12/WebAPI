﻿using CommonLayer.Model;
using MangerLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System.Linq;

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


    }
}
