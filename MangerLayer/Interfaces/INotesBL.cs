using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
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
        public bool Archive(int User_id, long NoteId);
        public bool PinNote(int User_id, long NoteId);
        public bool TrashNote(int User_id, long NoteId);
        public bool DeleteForever(int User_id, long NoteId);
        public NoteEntity ChangeColor(int User_Id, long NoteId, string colour);
        public NoteEntity Remainder(int User_Id, long NoteId, DateTime reminder);
        public string UploadImage(int User_Id, long NoteId, IFormFile img);


    }
}
