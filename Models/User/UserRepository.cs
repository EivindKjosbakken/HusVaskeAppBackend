
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq.Expressions;
using System.Linq;
using HusVaskeIdeBackend.Data;
using Microsoft.EntityFrameworkCore;
using HusVaskeIdeBackend.Models.TodoItem;

namespace HusVaskeIdeBackend.Models.User

{
    public class UserRepository : IUserRepository
        {
        private AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool isEmailUniq(string email)
        {
            var user = this.GetSingle(u => u.Email == email);
            return user == null;
        }

        public bool IsUsernameUniq(string username)
        {
            var user = this.GetSingle(u => u.Username == username);
            return user == null;
        }

        public virtual IEnumerable<UserItem> GetAll()
        {
            return _context.Users.ToList();
        }

        public virtual int Count()
        {
            return _context.Set<UserItem>().Count();
        }
        public virtual IEnumerable<UserItem> AllIncluding(params Expression<Func<UserItem, object>>[] includeProperties)
        {
            IQueryable<UserItem> query = _context.Set<UserItem>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public UserItem GetSingle(string id)
        {
            return _context.Set<UserItem>().FirstOrDefault(x => x.Id == id);
        }

        public UserItem GetSingle(Expression<Func<UserItem, bool>> predicate)
        {
            return _context.Set<UserItem>().FirstOrDefault(predicate);
        }

        public UserItem GetSingle(Expression<Func<UserItem, bool>> predicate, params Expression<Func<UserItem, object>>[] includeProperties)
        {
            IQueryable<UserItem> query = _context.Set<UserItem>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }

        public virtual IEnumerable<UserItem> FindBy(Expression<Func<UserItem, bool>> predicate)
        {
            return _context.Set<UserItem>().Where(predicate);
        }

        public virtual void Add(UserItem entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(UserItem entity)
        {
            Console.WriteLine("FUNKER IKKE NÅ");
        }
        public virtual void Delete(UserItem entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public virtual void DeleteWhere(Expression<Func<UserItem, bool>> predicate)
        {
            Console.WriteLine("FUNKER IKKE NÅ");

        }

        public string GetUserIDFromEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(obj => obj.Email == email);
            return user.Id;
        }

        public UserItem GetUserFromEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(obj => obj.Email == email);
            return user;
        }

        public virtual void Commit()
        {
            _context.SaveChanges();
        }
    }
    }
