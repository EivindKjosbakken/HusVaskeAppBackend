using System;
using System.ComponentModel.DataAnnotations;

namespace HusVaskeIdeBackend.Models.TodoItem
{
    public class TodoItem
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string GroupID { get; set; }

        [Required]
        public string AssigneeUserID { get; set; }

        public string CreatedByUserID { get; set; }

        public string? Title { get; set; }


        public string? Location { get; set; }

        public string Assignee { get; set; }

        public bool? IsFinished { get; set; }

        public DateTime TimeCreated { get; set; }

        public DateTime? TimeFinished { get; set; }

        public bool IsShowProof { get; set; }

        public double Price { get; set; } 

        public byte[]? ProofImage  { get; set; }

        


    }
}
