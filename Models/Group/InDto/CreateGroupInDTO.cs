﻿using System.ComponentModel.DataAnnotations;

namespace HusVaskeIdeBackend.Models.Group.InDto
{
    public class CreateGroupInDTO
    {
        [Required]
        public string UserID { get; set; }


        [Required]
        public string GroupName { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
