using HusVaskeIdeBackend.Models;
using HusVaskeIdeBackend.Models.Group.InDto;
using HusVaskeIdeBackend.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Any;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HusVaskeIdeBackend.Models.Group
{

    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;

        private IGroupRepository _repository;
        public GroupController(ILogger<GroupController> logger, IGroupRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("api/groups/")]

        public IEnumerable<GroupItem> GetAllGroups()
        {
            return _repository.GetAllGroups();
        }


        [HttpPost]
        [Route("api/addusertogroup")]
        [Consumes("application/json")]
        public void AddUserToGroup([FromBody] AddUserInDTO addUserInDto)
        {
            var groupName = _repository.GetGroupNameFromGroupID(addUserInDto.GroupID);
            if (groupName == null)
            {
                throw new Exception("Error when adding user to group");
            }
            GroupItem group = new GroupItem
            {
                GroupID = addUserInDto.GroupID,
                UserID = addUserInDto.UserID,
                GroupName = groupName,
                Role = addUserInDto.Role,
            };
            _repository.AddUserToGroup(group);
        }

        [HttpPost]
        [Route("api/creategroup")]
        [Consumes("application/json")]
        public void CreateGroup([FromBody] CreateGroupInDTO createGroupInDto)
        {

            var groupID = Guid.NewGuid().ToString(); //generate groupId
            GroupItem group = new GroupItem
            {
                GroupID = groupID,
                UserID = createGroupInDto.UserID,
                GroupName = createGroupInDto.GroupName,
                Role = createGroupInDto.Role,
            };
            _repository.AddUserToGroup(group);
        }


        [HttpPut]
        [Route("api/editrole/{userID:int}/{groupID}")]
        [Consumes("application/json")]
        public void EditUserRoleInGroup(int userID, string groupID, string newRole)
        {
            Console.WriteLine("fikser");
        }

    }
}