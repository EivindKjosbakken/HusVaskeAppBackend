using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using HusVaskeIdeBackend.Data;

namespace HusVaskeIdeBackend.Models.Group

{
    public class GroupRepository : IGroupRepository
    {
        private AppDbContext _context;

        public GroupRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GroupItem> GetAllGroups()
        {
            return _context.Groups.ToList();
            //return _context.Groups.Where(obj => (obj.GroupID == ID)).ToList();
        }

        public void AddUserToGroup(GroupItem group)
        {
            _context.Add(group);
            _context.SaveChanges();
        }

        public string GetGroupNameFromGroupID(string groupID)
        {
            var group = _context.Groups.FirstOrDefault(obj => obj.GroupID == groupID);
            return group.GroupName;
        }

    }
}