using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace RepositoryLayer.Entity
{
    public class CollaboratorEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Collaborator_ID { get; set; }
        public string collaborator_Email { get; set; }
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
