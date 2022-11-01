using System.ComponentModel.DataAnnotations;

namespace HusVaskeIdeBackend.Models.Group
{
    public class GroupItem
    {

        [Key]
        public int UserID { get; set; }

        [Required]
        public string GroupID { get; set; }

        [Required]
        public string GroupName { get; set; }
        [Required]
        public string Role { get; set; }


    }
}
