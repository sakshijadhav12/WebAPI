using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;
using System.Text.Json.Serialization;

namespace RepositoryLayer.Entity
{
    public class NoteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long NoteId { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public DateTime? Reminder { get; set; }
        public string color { get; set; }
        public string Image { get; set; }
        public bool IsArchive { get; set; }
        public bool IsPin { get; set; }
        public bool IsTrash { get; set; }
        public DateTime? Createat { get; set; }
        public DateTime? Updateat { get; set;}
        [ForeignKey("User")]
        public int User_Id { get; set; }
        [JsonIgnore]
        public virtual UserEntity User { get; set; }



    }
}
