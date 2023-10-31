using CommonLayer.Model;
using MangerLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace MangerLayer.Services
{
    public class NotesBL : INotesBL
    {
        private readonly INotesRL userInterface;
        public NotesBL(INotesRL userInterface)
        {
            this.userInterface = userInterface;
        }

        public NoteEntity AddNote(Notes node, int User_id)
        {
            try
            {
                return this.userInterface.AddNote(node, User_id);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<NoteEntity> DisplayNotes(int user_Id)
        {
            try
            {
                return this.userInterface.DisplayNotes(user_Id);

            }
            catch (Exception)
            {
                throw;
            }

        }
        public NoteEntity updateNotes(Notes node, int User_id)
        {
            try
            {
                return this.userInterface.updateNotes(node, User_id);

            }
            catch (Exception)
            {
                throw;
            }

        }
        public NoteEntity DeleteNote(long NoteId)
        {
            try
            {
                return this.userInterface.DeleteNote(NoteId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Archive(int User_id, long NoteId)
        {
            try
            {
                return this.userInterface.Archive(User_id, NoteId);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public bool PinNote(int User_id, long NoteId)
        {
            try
            {
                return this.userInterface.Archive(User_id, NoteId);
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
                return this.userInterface.Archive(User_id, NoteId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool DeleteForever(int User_id, long NoteId)
        {
            try
            {
                return this.userInterface.DeleteForever(User_id, NoteId);
            }
            catch( Exception ex) 
            {
                throw;
            }
        }
        public NoteEntity ChangeColor(int User_Id, long NoteId, string colour)
        {
            try
            {
                return this.userInterface.ChangeColor(User_Id, NoteId, colour);
               
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public NoteEntity Remainder(int User_Id, long NoteId, DateTime reminder)
        {
            try
            {
                return this.userInterface.Remainder(User_Id, NoteId, reminder);
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
                return this.userInterface.UploadImage(User_Id, NoteId, img);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
