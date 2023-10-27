using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
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

    }
}

