using MangerLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace MangerLayer.Services
{
    public  class LabelBL: ILabelBL
    {
        private readonly ILabelRL userInterface;
        public LabelBL(ILabelRL userInterface)
        {
            this.userInterface = userInterface;
        }

        public LabelEntity AddLabel(int user_Id, long NoteId, string label)
        {
            try
            {
               return this.userInterface.AddLabel(user_Id, NoteId, label);
              
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public List<LabelEntity> DisplayAllLabel()
        {
            try
            {
                return this.userInterface.DisplayAllLabel();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public LabelEntity RemoveLabel(long LabelId)
        {
            try
            {
                return this.userInterface.RemoveLabel(LabelId); 
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public LabelEntity UpdateLabel(long NoteId, long LabelId, string Label)
        {
            try
            {
                return this.userInterface.UpdateLabel(NoteId, LabelId, Label);  
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
