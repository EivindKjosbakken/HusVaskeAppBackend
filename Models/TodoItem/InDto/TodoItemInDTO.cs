using System.ComponentModel.DataAnnotations;

namespace HusVaskeIdeBackend.Models

{
    public class TodoItemInDTO
    {
        [Required]
        public string GroupID { get; set; }

        [Required]
        public string AssigneeUserID { get; set; }

        public string? Title { get; set; }

        public string? Location { get; set; }

        [Required]
        public string Assignee { get; set; }

        [Required]
        public string CreatedByUserID { get; set; }

        public bool IsShowProof { get; set; }

        public double Price { get; set; }




    }
}