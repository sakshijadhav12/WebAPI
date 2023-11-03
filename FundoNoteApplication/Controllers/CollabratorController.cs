using CommonLayer.Model;
using MangerLayer.Interfaces;
using MangerLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace FundoNoteApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollabratorController : ControllerBase
    {
        private readonly ICollaboratorBL collaboratorBL;
        public CollabratorController(ICollaboratorBL collaboratorBL)
        {
            this.collaboratorBL = collaboratorBL;
        }
        [Authorize]
        [HttpPost]
        [Route("AddCollborator")]
        public IActionResult AddCollaborator(long NoteId ,string CollaboratorEmail)
        {
            try
            {
               int User_Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "User_Id").Value);
                var result = collaboratorBL.AddCollaborator(User_Id,NoteId, CollaboratorEmail);
                if(result != null)
                {
                    return Ok(new ResponseModel<CollaboratorEntity> { Status = true, Message = "added sssuccessfully ", Data = result });
                }
                else
                {
                    return BadRequest(new ResponseModel<CollaboratorEntity> { Status = false, Message = "not added successfully" });
                }

            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("Display_collabrator")]
        public IActionResult DisplayCollborator()
        {
            try
            {
                var result = collaboratorBL.DisplayCollaborator();
                if(result != null) 
                {
                    return Ok(new  ResponseModel<List<CollaboratorEntity> >{ Status = true, Message = "added sssuccessfully ", Data = result });
                }
                else
                {
                    return BadRequest(new ResponseModel<List<CollaboratorEntity>> { Status = false, Message = "not added successfully" });
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPost]
        [Route("remove_collaborator")]
        public IActionResult RemoveCollaborator(string Collb_Email)
        {
            try
            {
                int User_id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "User_Id").Value);
                var result = collaboratorBL.RemoveCollaborator(User_id, Collb_Email);
                if (result != null)
                {
                    return Ok(new ResponseModel<CollaboratorEntity> { Status = true, Message = "removed sssuccessfully ", Data = result });
                }
                else
                {
                    return BadRequest(new ResponseModel<CollaboratorEntity> { Status = false, Message = "not removeded successfully" });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
