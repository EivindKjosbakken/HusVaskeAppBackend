using System.Collections.Generic;

namespace HusVaskeIdeBackend.Models.Group
{
    public interface IGroupRepository
    {
        public IEnumerable<GroupItem> GetAllGroups();
        public void AddUserToGroup(GroupItem group);
        public string GetGroupNameFromGroupID(string groupID);
    }
}
