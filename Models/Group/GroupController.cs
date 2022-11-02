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

        private IUserRepository _userRepository;
        public GroupController(ILogger<GroupController> logger, IGroupRepository repository, IUserRepository userRepository)
        {
            _logger = logger;
            _repository = repository;
            _userRepository = userRepository;
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
        [Route("api/creategroup")]
        [Consumes("application/json")]
        public void CreateGroup([FromBody] CreateGroupInDTO createGroupInDto)
        {
            var user = _userRepository.GetSingle(u => u.Id == createGroupInDto.UserID);
            if (user == null)
            {
                throw new Exception("User must exist");
            }


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

        [HttpPost]
        [Route("api/addusertogroup")]
        [Consumes("application/json")]
        public void AddUserToGroup([FromBody] AddUserInDTO addUserInDto)
        {
            var groupID = _repository.GetGroupIDFromGroupName(addUserInDto.GroupName);

            var userID = _userRepository.GetUserIDFromEmail(addUserInDto.UserEmail);

            if (groupID == null)
            {
                throw new Exception("Error when adding user to group");
            }
            GroupItem group = new GroupItem
            {
                GroupID = groupID,
                UserID = userID,
                GroupName = addUserInDto.GroupName,
                Role = addUserInDto.Role,
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