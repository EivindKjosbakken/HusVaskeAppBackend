using System.ComponentModel.DataAnnotations;

namespace HusVaskeIdeBackend.Models.Group.InDto
{
    public class AddUserInDTO
    {

        [Required]
        public int UserID { get; set; }

        [Required]
        public string GroupID { get; set; }

        [Required]
        public string Role { get; set; }

    }
}
