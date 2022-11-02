using System.ComponentModel.DataAnnotations;

namespace HusVaskeIdeBackend.Models.Group
{
    public class GroupItem
    {

        [Key]
        public string UserID { get; set; }

        [Required]
        public string GroupID { get; set; }

        [Required]
        public string GroupName { get; set; }
        [Required]
        public string Role { get; set; }

        public bool IsOwner { get; set; }


    }
}
