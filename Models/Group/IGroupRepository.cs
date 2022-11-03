using HusVaskeIdeBackend.Models.Group.InDto;
using HusVaskeIdeBackend.Models.User;
using System.Collections.Generic;

namespace HusVaskeIdeBackend.Models.Group
{
    public interface IGroupRepository
    {
        public IEnumerable<GroupItem> GetAllGroups();
        public void AddUserToGroup(GroupItem group);
        public string GetGroupIDFromGroupName(string groupID);

        public string GetGroupNameFromGroupID(string groupID);

        public IEnumerable<GroupItem> GetGroupInstancesFromGroupID(string groupID);

        public IEnumerable<GroupItem> GetAllGroupsUserIsOwnerOf(string userID);

        public IEnumerable<string> GetAllUserIDsInGroup(string groupID);
    }
}
