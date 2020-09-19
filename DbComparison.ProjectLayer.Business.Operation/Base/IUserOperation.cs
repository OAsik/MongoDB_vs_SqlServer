using System;
using System.Collections.Generic;
using DbComparison.DataLayer.Base;
using DbComparison.ProjectLayer.Data.Common.Model;

namespace DbComparison.ProjectLayer.Business.Operation.Base
{
    public interface IUserOperation
    {
        User InsertUser(User user, DbType dbType);

        List<User> InsertUsers(List<User> userList, DbType dbType);

        User GetSingleUser(string id, DbType dbType);

        List<User> GetAllUsers(DbType dbType);

        User UpdateUser(User user, DbType dbType);

        bool DeleteUser(string id, DbType dbType);

        bool DeleteUsers(List<string> idList, DbType dbType);
    }
}