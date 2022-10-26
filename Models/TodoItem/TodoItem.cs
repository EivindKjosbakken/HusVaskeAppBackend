using System.ComponentModel.DataAnnotations;

namespace HusVaskeIdeBackend.Models.TodoItem
{
    public class TodoItem
    {
        [Required]
        public int ID { get; set; }


        public string? Title { get; set; }


        public string? Location { get; set; }

        public string Assignee { get; set; }
    }
}
