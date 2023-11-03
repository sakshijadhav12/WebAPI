using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MangerLayer.Interfaces
{
    public interface ICollaboratorBL
    {
        public CollaboratorEntity AddCollaborator(int User_id, long NoteId, string CollaboraotEmail);
        public List<CollaboratorEntity> DisplayCollaborator();
        public CollaboratorEntity RemoveCollaborator(int User_id, string Collb_Email);
    }
}
