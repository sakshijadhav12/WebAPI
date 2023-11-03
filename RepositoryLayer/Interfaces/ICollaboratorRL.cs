using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface ICollaboratorRL
    {
        public CollaboratorEntity AddCollaborator(int User_id, long NoteId, string CollaboraotEmail);
        public List<CollaboratorEntity> DisplayCollaborator();
        public CollaboratorEntity RemoveCollaborator(int User_id, string Collb_Email);
    }
}
