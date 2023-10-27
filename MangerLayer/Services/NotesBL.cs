using CommonLayer.Model;
using MangerLayer.Interfaces;
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
    }
}
