
using System;
using System.Collections.Generic;

namespace HusVaskeIdeBackend.Models.User
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetAll();

        UserModel Add(UserModel user);
    }
}