using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class Notes
    {
        public string Title { get; set; }
        public string Note { get; set; }
        public DateTime? Reminder { get; set; }
        public string color { get; set; }
        public string Image { get; set; }
        public bool IsArchive { get; set; }
        public bool IsPin { get; set; }
        public bool IsTrash { get; set; }
        public DateTime? Createat { get; set; }
        public DateTime? Updateat { get; set; }
    }
}
