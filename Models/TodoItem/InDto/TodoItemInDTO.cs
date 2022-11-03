using System.ComponentModel.DataAnnotations;

namespace HusVaskeIdeBackend.Models

{
    public class TodoItemInDTO
    {
        [Required]
        public string GroupID { get; set; }

        [Required]
        public string UserID { get; set; }

        public string? Title { get; set; }

        public string? Location { get; set; }

        public string? Assignee { get; set; }



    }
}