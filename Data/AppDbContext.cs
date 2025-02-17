﻿
using HusVaskeIdeBackend.Models.Group;
using HusVaskeIdeBackend.Models.TodoItem;
using HusVaskeIdeBackend.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HusVaskeIdeBackend.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<UserItem> Users { get; set; }

        public DbSet<GroupItem> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GroupItem>().HasKey(pc => new { pc.UserID, pc.GroupID }); //have composite PK, want each user to max be once in each group
            // Code to seed data
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem { ID = 1, Title = "Oppvask", Location="Oslo", Assignee="Eivind", AssigneeUserID="TestUserID", IsFinished=false, GroupID = "TestGroupID123", TimeCreated = DateTime.UtcNow, CreatedByUserID = "assndfnq_sa123", IsShowProof=true, Price=5.0, ProofImage = {} });

            modelBuilder.Entity<UserItem>().HasData(
                new UserItem { Id = "assndfnq_sa123", Username = "Kjosbakken", Email = "eivind@gmail.com", Password = "ANAKJFNSOA" });

            modelBuilder.Entity<GroupItem>().HasData(
                 new GroupItem { GroupID = "XJSNADSKJDASDNAKSAN", UserID = "KJNSKANSAKJ;HI", GroupName = "Kjosbakken", Role = "Parent", IsOwner = false,  });

        }
    }
}

