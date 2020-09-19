using System;
using System.Collections.Generic;
using DbComparison.DataLayer.Base;
using DbComparison.ProjectLayer.Repository.Base;
using DbComparison.ProjectLayer.Data.Common.Model;
using DbComparison.ProjectLayer.Business.Operation.Base;

namespace DbComparison.ProjectLayer.Business.Operation
{
    public class UserOperation : IUserOperation
    {
        //Mapping entity objects to DTOs or error handling is simply out of the scope for this project. My aim is simply to compare the amount of time on spending reading/writing while using different DB providers. Do not skip to convert data base entities to DTOs in real life projects --Özgür

        IUserRepository<User> _userRepository;

        public UserOperation(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User InsertUser(User user, DbType dbType)
        {
            if (dbType == DbType.SqlServer)
            {
                user.UserId = Guid.NewGuid();
            }
            else if (dbType == DbType.MongoDB)
            {
                user.Id = Guid.NewGuid().ToString();
            }

            return _userRepository.GetRepository(dbType).Insert(user);
        }

        public List<User> InsertUsers(List<User> userList, DbType dbType)
        {
            userList.ForEach(user =>
            {
                if (dbType == DbType.SqlServer)
                {
                    user.UserId = Guid.NewGuid();
                }
                else if (dbType == DbType.MongoDB)
                {
                    user.Id = Guid.NewGuid().ToString();
                }
            });

            return _userRepository.GetRepository(dbType).InsertRange(userList);
        }

        public User GetSingleUser(string id, DbType dbType)
        {
            if (dbType == DbType.SqlServer)
            {
                return _userRepository.GetRepository(dbType).GetSingle(Guid.Parse(id));
            }
            else if (dbType == DbType.MongoDB)
            {
                return _userRepository.GetRepository(dbType).GetSingle(x => x.Id == id);
            }
            else
            {
                throw new NotImplementedException("Undefined DB provider");
            }
        }

        public List<User> GetAllUsers(DbType dbType)
        {
            return _userRepository.GetRepository(dbType).GetAll();
        }

        public User UpdateUser(User user, DbType dbType)
        {
            if (dbType == DbType.SqlServer)
            {
                return _userRepository.GetRepository(dbType).Update(user);
            }
            else if (dbType == DbType.MongoDB)
            {
                return _userRepository.GetRepository(dbType).Update(x => x.UserId == user.UserId, user);
            }
            else
            {
                throw new NotImplementedException("Undefined DB provider");
            }
        }

        public bool DeleteUser(string id, DbType dbType)
        {
            return _userRepository.GetRepository(dbType).Delete(Guid.Parse(id));
        }

        public bool DeleteUsers(List<string> idList, DbType dbType)
        {
            if (dbType == DbType.SqlServer)
            {
                List<Guid> guidList = new List<Guid>();

                idList.ForEach(id =>
                {
                    Guid guidId = Guid.Parse(id);

                    guidList.Add(guidId);
                });

                return _userRepository.GetRepository(dbType).DeleteRange(guidList);
            }
            else if (dbType == DbType.MongoDB)
            {
                List<bool> resultList = new List<bool>();
                List<Guid> guidList = new List<Guid>();

                idList.ForEach(id =>
                {
                    Guid guidId = Guid.Parse(id);

                    guidList.Add(guidId);
                });

                guidList.ForEach(id =>
                {
                    bool result = _userRepository.GetRepository(dbType).DeleteRange(x => x.UserId == id);

                    resultList.Add(result);
                });

                foreach (bool result in resultList)
                {
                    if (!result)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

                return false;
            }
            else
            {
                throw new NotImplementedException("Undefined DB provider");
            }
        }
    }
}