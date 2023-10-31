using CommonLayer.Model;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Xml.Linq;

namespace RepositoryLayer.Services
{
    public class LabelRL : ILabelRL
    {
        private readonly FundoDbContext fundoDbContext;
        private readonly IConfiguration configuration;

        public LabelRL(FundoDbContext fundoDbContext, IConfiguration configuration)
        {
            this.fundoDbContext = fundoDbContext;
            this.configuration = configuration;
        }

        public LabelEntity AddLabel(int user_Id, long NoteId, string label)
        {
            try
            {
                LabelEntity labelEntity = new LabelEntity();
                labelEntity.LableName = label;
                labelEntity.NoteId = NoteId;
                labelEntity.User_Id = user_Id;
                fundoDbContext.LabelsTable.Add(labelEntity);
                int result = fundoDbContext.SaveChanges();
                if (result > 0)
                {
                    return labelEntity;
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
        public List<LabelEntity> DisplayAllLabel()
        {
            try
            {

                List<LabelEntity> result = (List<LabelEntity>)fundoDbContext.LabelsTable.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public LabelEntity RemoveLabel(long LabelId)
        {
            try
            {
                    var LabelExicts = fundoDbContext.LabelsTable.FirstOrDefault(x => x.LabelId == LabelId);
                    if (LabelExicts != null)
                    {
                        fundoDbContext.LabelsTable.Remove(LabelExicts);
                        int result = fundoDbContext.SaveChanges();
                        if (result > 0)
                        {
                            return LabelExicts;
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

        public LabelEntity UpdateLabel(long NoteId, long LabelId, string Label)
        {
            try
            {

                var LabelExicts = fundoDbContext.LabelsTable.FirstOrDefault(x => x.LabelId == LabelId);
                if (LabelExicts != null)
                {
                   
                    LabelExicts.NoteId = NoteId;
                    LabelExicts.LabelId = LabelId;
                   LabelExicts.LableName = Label;
                    int result = fundoDbContext.SaveChanges();
                    if (result > 0)
                    {
                        return  LabelExicts;
                      
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

                throw ex;
            }
        }

    }
}


