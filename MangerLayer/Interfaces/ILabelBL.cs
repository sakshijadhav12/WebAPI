﻿using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MangerLayer.Interfaces
{
    public interface  ILabelBL 
    {
        public LabelEntity AddLabel(int user_Id, long NoteId, string label);
        public List<LabelEntity> DisplayAllLabel();
       
        public LabelEntity RemoveLabel(long LabelId);
    
        public LabelEntity UpdateLabel(long NoteId, long LabelId, string Label);
    }
}