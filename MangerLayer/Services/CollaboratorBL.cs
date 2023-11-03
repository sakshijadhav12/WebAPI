using MangerLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MangerLayer.Services
{
    public class CollaboratorBL :ICollaboratorBL
    {
     
            private readonly ICollaboratorRL userInterface;
            public CollaboratorBL(ICollaboratorRL userInterface)
            {
                this.userInterface = userInterface;
            }

            public CollaboratorEntity AddCollaborator(int User_id, long NoteId, string CollaboraotEmail)
        {
            try
            { 
               return this.userInterface.AddCollaborator(User_id, NoteId, CollaboraotEmail);

            }
            catch(Exception ex) 
            {
                throw;
            }
        }

        public List<CollaboratorEntity> DisplayCollaborator()
        { 
            try
            {
                return this.userInterface.DisplayCollaborator();
            }
            catch(Exception ex) 
            {
                throw;
            }
        }
        public CollaboratorEntity RemoveCollaborator(int User_id, string Collb_Email)
        {
            try
            {
                return this.userInterface.RemoveCollaborator(User_id, Collb_Email);
            }
            catch(Exception ex) 
            {
                throw;
            }
        }
    }
}
