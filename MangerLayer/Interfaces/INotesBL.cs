using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MangerLayer.Interfaces
{
    public interface INotesBL
    {
        public NoteEntity AddNote(Notes node, int User_id);
        public List<NoteEntity> DisplayNotes(int user_Id);
        public NoteEntity updateNotes(Notes node, int User_id);
        public NoteEntity DeleteNote(long NoteId);
    }
}
