using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NotesRL : INotesRL
    {
        private readonly FundoDbContext fundoDbContext;
        private readonly IConfiguration configuration;

        public NotesRL(FundoDbContext fundoDbContext, IConfiguration configuration)
        {
            this.fundoDbContext = fundoDbContext;
            this.configuration = configuration;
        }

        public NoteEntity AddNote(Notes node, int User_id)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();
                noteEntity.Title = node.Title;
                noteEntity.Note = node.Note;
                noteEntity.Reminder = node.Reminder;
                noteEntity.color = node.color;
                noteEntity.Image = node.Image;
                noteEntity.IsArchive = node.IsArchive;
                noteEntity.IsPin = node.IsPin;
                noteEntity.IsTrash = node.IsTrash;
                noteEntity.User_Id = User_id;
                noteEntity.Createat = node.Createat;
                noteEntity.Updateat = node.Updateat;
                fundoDbContext.NoteTable.Add(noteEntity);
                int result = fundoDbContext.SaveChanges();
                if (result > 0)
                {
                    return noteEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public List<NoteEntity> DisplayNotes(int user_Id)
        {
            try
            {
                List<NoteEntity> result = (List<NoteEntity>)fundoDbContext.NoteTable.Where(x => x.User_Id == user_Id).ToList();
                return result;
              
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public NoteEntity updateNotes(Notes node, int User_id)
        {
            try
            {
                var UserExicts = fundoDbContext.NoteTable.FirstOrDefault(x => x.User_Id == User_id);
                if (UserExicts != null)
                {
                    NoteEntity noteEntity = new NoteEntity();
                    noteEntity.Title = node.Title;
                    noteEntity.Note = node.Note;
                    noteEntity.Reminder = node.Reminder;
                    noteEntity.color = node.color;
                    noteEntity.Image = node.Image;
                    noteEntity.IsArchive = node.IsArchive;
                    noteEntity.IsPin = node.IsPin;
                    noteEntity.IsTrash = node.IsTrash;
                    noteEntity.User_Id = User_id;
                    noteEntity.Createat = node.Createat;
                    noteEntity.Updateat = node.Updateat;
                    int result = fundoDbContext.SaveChanges();
                    if (result > 0)
                    {
                        return noteEntity;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public NoteEntity DeleteNote(long NoteId)
        {
            try {
                var NoteExicts = fundoDbContext.NoteTable.FirstOrDefault(x => x.NoteId == NoteId);
                if (NoteExicts != null)
                {
                    fundoDbContext.NoteTable.Remove(NoteExicts);
                    int result = fundoDbContext.SaveChanges();
                    if (result > 0) 
                    {
                        return NoteExicts;
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    return null;
                }

            }
            catch(Exception ex)
            {
                throw;
            }
         }

        public bool Archive (int User_id ,long NoteId )
        {
            try
            {
                NoteEntity result = fundoDbContext.NoteTable.FirstOrDefault(x=>x.User_Id== User_id &&  x.NoteId == NoteId);
                if(result.IsArchive == true)
                {
                    result.IsArchive = false;
                    this.fundoDbContext.SaveChanges();
                    return false;
                }
                else
                {
                    result.IsArchive = true;
                    this.fundoDbContext.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public bool PinNote(int User_id ,long NoteId)
        {
            try
            {
                NoteEntity result =fundoDbContext.NoteTable.FirstOrDefault(x=>x.User_Id == User_id && x.NoteId== NoteId);
                if (result.IsPin == true)
                {
                    result.IsPin =false;
                    this.fundoDbContext.SaveChanges();
                    return false;
                }
                else
                {
                    result.IsPin = true;
                    this.fundoDbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool TrashNote(int User_id, long NoteId)
        {
            try
            {
                NoteEntity result = fundoDbContext.NoteTable.FirstOrDefault(x => x.User_Id == User_id && x.NoteId == NoteId);
                if (result.IsTrash == true)
                {
                    result.IsTrash = false;
                    this.fundoDbContext.SaveChanges();
                    return false;
                }
                else
                {
                    result.IsTrash = true;
                    this.fundoDbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool DeleteForever(int User_id , long NoteId) 
        {
            try
            {
                NoteEntity result = this.fundoDbContext.NoteTable.FirstOrDefault(x => x.User_Id == User_id && x.NoteId == NoteId);
                if (result.IsTrash == true)
                {
                    this.fundoDbContext.Remove(result);
                    this.fundoDbContext.SaveChanges();
                    return false;
                }
                else
                {
                    result.IsTrash = true;
                    this.fundoDbContext.SaveChanges();
                    return true;
                }

            }
            catch(Exception ex )
            {
                throw;
            }
        }

        public NoteEntity ChangeColor(int User_Id,long NoteId, string colour)
        {
            try
            {
                NoteEntity result = this.fundoDbContext.NoteTable.FirstOrDefault(x => x.User_Id == User_Id && x.NoteId == NoteId);
                if(result.color != null)
                {
                    result.color = colour;
                    this.fundoDbContext.SaveChanges();
                    return result;

                }
                else
                {
                    return null;
                }

            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public NoteEntity Remainder(int User_Id,long NoteId,DateTime reminder)
        {
            try
            {
                NoteEntity result = this.fundoDbContext.NoteTable.FirstOrDefault(x => x.User_Id == User_Id && x.NoteId == NoteId);
                if(result.Reminder != null)
                {
                    result.Reminder = reminder;
                    this.fundoDbContext.SaveChanges();
                    return result;
                }
                else
                {
                    return null;
                }

            }
            catch(Exception ex) 
            {
                throw;
            }

           
        }
        public string UploadImage(int User_Id, long NoteId, IFormFile img)
        {
            try
            {
                var result = this.fundoDbContext.NoteTable.FirstOrDefault(x => x.User_Id == User_Id && x.NoteId == NoteId);
                if (result != null)
                {
                    Account account = new Account
                    ("dgdrh4evk",
                    "911559966985641",
                    "49LMb0to77GiYj70NAlGK35xeTA");

                    Cloudinary cloudinary = new Cloudinary(account);
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(img.FileName, img.OpenReadStream()),
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);
                    string imgpath = uploadResult.Url.ToString();
                    result.Image = imgpath;
                    fundoDbContext.SaveChanges();
                    return "Image uploaded successfully";
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                       throw;
                   }
                }

            }
}

