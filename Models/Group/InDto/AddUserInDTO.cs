using System.ComponentModel.DataAnnotations;

namespace HusVaskeIdeBackend.Models.Group.InDto
{
    public class AddUserInDTO
    {

        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string GroupName { get; set; }
        [Required]
        public string Role { get; set; }



    }
}
