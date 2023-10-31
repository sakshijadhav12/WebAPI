using CommonLayer.Model;
using MangerLayer.Interfaces;
using MangerLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using RepositoryLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace FundoNoteApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly ILabelBL labelBL;

        public LabelController(ILabelBL labelBL)
        {
            this.labelBL = labelBL;
        }
        [Authorize]
        [HttpPost]
        [Route("AddLabel")]
        public IActionResult AddLabel(int user_Id, long NoteId, string label)
        {
            try
            {
                int User_Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "User_Id").Value);
                var result = labelBL.AddLabel(user_Id, NoteId, label);
                if (result != null)
                {
                    return Ok(new ResponseModel<LabelEntity> { Status = true, Message = "Label is added successfully", Data = result });
                }
                else
                {
                    return BadRequest(new ResponseModel<LabelEntity> { Status = false, Message = "not successfull" });
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("displaylables")]
        public IActionResult DisplayAllLabel()
        {
            var result = labelBL.DisplayAllLabel();
            if (result != null)
            {
                return Ok(new ResponseModel<List<LabelEntity>> { Status = true, Message = "successfull", Data = result });
            }
            else
            {
                return BadRequest(new ResponseModel<List<LabelEntity>> { Status = false, Message = "Not successfull" });
            }
        }
        [Authorize]
        [HttpPost]
        [Route("removelables")]
        public IActionResult RemoveLabel(long LabelId)
        {
            var result = labelBL.RemoveLabel(LabelId);
            if (result != null)
            {
                return Ok(new ResponseModel<LabelEntity> { Status = true, Message = "label is deleted successfully", Data = result });
            }
            else
            {
                return BadRequest(new ResponseModel<LabelEntity> { Status = false, Message = "Not successfull" });
            }
        }

        [Authorize]
        [HttpPost]
        [Route("UpdateLabel")]
        public IActionResult UpdateLabel(long NoteId, long LabelId, string Label)
        {
            try
            {
                int User_Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "User_Id").Value);
                var result = labelBL.UpdateLabel(NoteId,LabelId, Label);
                if (result != null)
                {
                    return Ok(new ResponseModel<LabelEntity> { Status = true, Message = "Label is updated successfully", Data = result });
                }
                else
                {
                    return BadRequest(new ResponseModel<LabelEntity> { Status = false, Message = "not successfull" });
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

   
}
