using CommonLayer.Model;
using MangerLayer.Interfaces;
using MangerLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using RepositoryLayer.Entity;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FundoNoteApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesBL notesBl;
        private readonly ILogger<UserController> logger;
        private readonly IDistributedCache distributedCache;


        public NotesController(INotesBL notesBl , ILogger<UserController> logger , IDistributedCache distributedCache)
        {
            this.notesBl = notesBl;
            this.logger = logger;
            this.distributedCache = distributedCache;

        }
        //[Authorize]
        [HttpPost]
        [Route("add_note")]
        public IActionResult AddNotes(Notes notes)
        {
            try
            {
                //  int User_Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "User_Id").Value);
                int User_ID = (int)HttpContext.Session.GetInt32("UserID");
                var result = notesBl.AddNote(notes, User_ID);
                if (result != null)
                {
                    return Ok(new ResponseModel<NoteEntity> { Status = true, Message = "note is added successfully", Data = result });
                }
                else
                {
                    return BadRequest(new ResponseModel<NoteEntity> { Status = false, Message = "Not successfull" });
                }


            }
            catch (Exception ex)
            {
                throw;
            }

        }
        [Authorize]
        [HttpPost]
        [Route("displyNotes")]
        public IActionResult display()
        {
            try
            {
                int User_Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "User_Id").Value);
                List<NoteEntity> result = notesBl.DisplayNotes(User_Id);
                if (result != null)

                {
                    return Ok(new ResponseModel<List<NoteEntity>> { Status = true, Message = " successfull", Data = result });
                }
                else
                {
                    return BadRequest(new ResponseModel<List<NoteEntity>> { Status = false, Message = "Not successfull" });
                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPost]
        [Route("getupdatebyuserId")]
        public IActionResult updateNotes(Notes node, int User_id)
        {
            try
            {
                int User_Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "User_Id").Value);
                var result = notesBl.AddNote(node, User_id);
                if (result != null)
                {
                    return Ok(new ResponseModel<NoteEntity> { Status = true, Message = " successfull", Data = result });
                }
                else
                {
                    return BadRequest(new ResponseModel<NoteEntity> { Status = false, Message = "Not successfull" });
                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPost]
        [Route("Delete")]
        public IActionResult DeleteNote(long NoteId)
        {
            try
            {
                int User_Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "User_Id").Value);
                var result = notesBl.DeleteNote(NoteId);
                if (result != null)
                {
                    return Ok(new ResponseModel<NoteEntity> { Status = true, Message = " successfully delete", Data = result });
                }
                else
                {
                    return BadRequest(new ResponseModel<NoteEntity> { Status = false, Message = "Not successfull" });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPost]
        [Route("Isarchive")]
        public IActionResult Archive(int User_id, long NoteId)
        {
            try
            {
                int User_Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "User_Id").Value);
                var result = notesBl.Archive(User_Id, NoteId);
                if (result != null)
                {
                    return Ok(new ResponseModel<bool> { Status = true, Message = " successfull", Data = result });
                }
                else
                {
                    return BadRequest(new ResponseModel<NoteEntity> { Status = false, Message = "Not successfull" });
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPost]
        [Route("IsPin")]
        public IActionResult PinNote(int User_id, long NoteId)
        {
            try
            {
                int User_Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "User_Id").Value);
                var result = notesBl.Archive(User_Id, NoteId);
                if (result != null)
                {
                    return Ok(new ResponseModel<bool> { Status = true, Message = " successfull", Data = result });
                }
                else
                {
                    return BadRequest(new ResponseModel<NoteEntity> { Status = false, Message = "Not successfull" });
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        [Authorize]
        [HttpPost]
        [Route("Istrash")]
        public IActionResult TrashNote(int User_id, long NoteId)
        {
            try
            {
                int User_Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "User_Id").Value);
                var result = notesBl.Archive(User_Id, NoteId);
                if (result != null)
                {
                    return Ok(new ResponseModel<bool> { Status = true, Message = " successfull", Data = result });
                }
                else
                {
                    return BadRequest(new ResponseModel<NoteEntity> { Status = false, Message = "Not successfull" });
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        [Authorize]
        [HttpPost]
        [Route("removeForever")]
        public IActionResult  DeleteForever( long NoteId)
        {
            try
            {
                int User_Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "User_Id").Value);
                var result =notesBl.DeleteForever(User_Id, NoteId);
                if(result != null)
                {
                    return Ok(new ResponseModel<bool> { Status = true, Message = "remove successfully", Data = result });
                }
                else
                {
                    return BadRequest(new ResponseModel<bool> { Status=false,Message="note is not deleted"});
                }

            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPost]
        [Route("changecolor")]
        public IActionResult ChangeColor( long NoteId, string colour)
        {
            int User_Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "User_Id").Value);
            var result = notesBl.ChangeColor(User_Id, NoteId, colour);
            if(result != null)
            {
                return Ok(new ResponseModel<NoteEntity> { Status=true,Message="Color is changed",Data=result});
            }
            else
            {
                return BadRequest(new ResponseModel<NoteEntity> { Status = false, Message = " color is not Changed" });
            }
                
        }
        [Authorize]
        [HttpPost]
        [Route("Reminder")]
        public IActionResult Remainder( long NoteId, DateTime reminder)
        {
            try
            {
                int User_Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "User_Id").Value);
                var result = notesBl.Remainder(User_Id,NoteId, reminder);
                if(result!= null)
                {
                    return Ok(new ResponseModel<NoteEntity> { Status = true, Message = "successfull", Data = result });
                }
                else
                {
                    return BadRequest(new ResponseModel<NoteEntity> { Status = false, Message = "not successfull" });
                }
            }
            catch(Exception ex)
            {
                throw;
            }

        }
        [Authorize]
        [HttpPost]
        [Route("Uploadimg")]
        public IActionResult UploadImage( long NoteId, IFormFile img)
        {
            try
            {
                int User_Id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "User_Id").Value);
                var result = notesBl.UploadImage(User_Id, NoteId,img);
                if (result != null)
                {
                    return Ok(new ResponseModel<string> { Status = true, Message = "successfullu uploaded image", Data = result });
                }
                else
                {
                    return BadRequest(new ResponseModel<string> { Status = false, Message = "image is not uploaded" });
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("GetAllnotesusingredis")]
        public async Task<IActionResult> GetALLNotesUsingRedis(int user_Id)
        {
            try {
                var CacheKey = "NotesList";
                //styring SerializedNotesList
                List<NoteEntity> NoteList = new List<NoteEntity>();
                byte[] RedisNoteList = await distributedCache.GetAsync(CacheKey);// for getting datA FROM CACHE
                if (RedisNoteList != null)
                {
                    logger.LogDebug("setting the list to cache which is requested for the first time");
                    var SerializedNoteList = Encoding.UTF8.GetString(RedisNoteList);
                    NoteList = JsonConvert.DeserializeObject<List<NoteEntity>>(SerializedNoteList);

                }
                else
                {
                    logger.LogDebug("setting a list to cache which is requested for the first time");
                    NoteList= (List<NoteEntity>)notesBl.DisplayNotes(user_Id);
                    var SeralizedNoteList = JsonConvert.SerializeObject(NoteList);
                    var redisNoteList = Encoding.UTF8.GetBytes(SeralizedNoteList);
                    var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(10)).SetSlidingExpiration(TimeSpan.FromMinutes(5));
                    await distributedCache.SetAsync(CacheKey, redisNoteList, options);

                }
                logger.LogInformation("got all notes list successfully from redis");
                return Ok(NoteList);

            }
            catch(Exception ex) 
            {
                logger.LogCritical(ex, "exception thrown.. ");
                return BadRequest(new ResponseModel<NoteEntity> { Status = false, Message = ex.Message } );
            }


 }
        }


    }
   


            
       
            

    


