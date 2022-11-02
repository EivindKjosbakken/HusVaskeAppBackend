
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using HusVaskeIdeBackend.Models.User;

namespace HusVaskeIdeBackend.Models.User

{
    public interface IUserRepository
    {
        public bool isEmailUniq(string email);
        public bool IsUsernameUniq(string username);
        IEnumerable<UserItem> AllIncluding(
          params Expression<Func<UserItem, object>>[] includeProperties
        );
        IEnumerable<UserItem> GetAll();
        int Count();
        UserItem GetSingle(string id);
        UserItem GetSingle(Expression<Func<UserItem, bool>> predicate);
        UserItem GetSingle(
          Expression<Func<UserItem, bool>> predicate,
          params Expression<Func<UserItem, object>>[] includeProperties
        );
        IEnumerable<UserItem> FindBy(Expression<Func<UserItem, bool>> predicate);

        void Add(UserItem entity);
        void Update(UserItem entity);
        void Delete(UserItem entity);
        void DeleteWhere(Expression<Func<UserItem, bool>> predicate);

        public string GetUserIDFromEmail(string email);

        public UserItem GetUserFromEmail(string email);
        void Commit();
    }
}