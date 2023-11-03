using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class CollaboratorRL: ICollaboratorRL
    {
        private readonly FundoDbContext fundoDbContext;
        private readonly IConfiguration configuration;

        public CollaboratorRL(FundoDbContext fundoDbContext, IConfiguration configuration)
        {
            this.fundoDbContext = fundoDbContext;
            this.configuration = configuration;
        }

        public CollaboratorEntity AddCollaborator(int User_id , long NoteId ,string CollaboraotEmail)
        {
            try
            {
                
                CollaboratorEntity collaboratorEntity = new CollaboratorEntity();
                collaboratorEntity.User_Id = User_id;
                collaboratorEntity.NoteId = NoteId;
                var email = fundoDbContext.User.FirstOrDefault(x => x.EmailId == CollaboraotEmail);
                collaboratorEntity.collaborator_Email = CollaboraotEmail;
                  fundoDbContext.CollaboratorTable.Add(collaboratorEntity);
                var result = fundoDbContext.SaveChanges();
                if(result>0)
                {
                    return collaboratorEntity;
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
        public List<CollaboratorEntity> DisplayCollaborator()
        {
            try
            {
                List<CollaboratorEntity> result = (List<CollaboratorEntity>)fundoDbContext.CollaboratorTable.ToList(); ;
                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public CollaboratorEntity RemoveCollaborator(int User_id ,string Collb_Email ) 
        {
            try
            {
                var collb_exicts = fundoDbContext.CollaboratorTable.FirstOrDefault(x => x.User_Id == User_id && x.collaborator_Email ==Collb_Email);
                if( collb_exicts!=null )
                {
                    fundoDbContext.Remove(collb_exicts);
                    var result = fundoDbContext.SaveChanges();
                    if(result>0)
                    {
                        return collb_exicts;
                    }
                    else
                    {
                        return null;
                    }
                }
                {
                    return null;
                }
            }
           catch(Exception ex)
            {
                throw;
            }
        }

        
    }
}
