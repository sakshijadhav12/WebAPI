using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace RepositoryLayer.Entity
{
    public  class LabelEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LabelId { get; set; }
        public string LableName { get; set; }
        [ForeignKey("User")]
        public int User_Id { get; set; }
        [JsonIgnore]
        public virtual UserEntity User { get; set; }

        [ForeignKey("NoteTable")]
        public long NoteId { get; set; }

        [JsonIgnore] 
        public virtual NoteEntity NoteTable { get; set; }
    }
}
