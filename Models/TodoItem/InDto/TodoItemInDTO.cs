using System.ComponentModel.DataAnnotations;

namespace HusVaskeIdeBackend.Models

{
    public class TodoItemInDTO
    {


        public string? Title { get; set; }

        public string? Location { get; set; }

        public string? Assignee { get; set; }

    }
}