using System;
using DbComparison.DataLayer.Base;
using DbComparison.DataLayer.Factory;
using DbComparison.ProjectLayer.Repository.Base;
using DbComparison.DataLayer.MongoDB.Setting.Base;
using DbComparison.ProjectLayer.Data.Common.Model;
using DbComparison.ProjectLayer.Data.SqlServer.DataContext;

namespace DbComparison.ProjectLayer.Repository
{
    public class UserRepository : IUserRepository<User>
    {
        private SqlServerDbContext _dbContext;
        public IMongoDbSetting _mongoDbSetting;

        public UserRepository(IMongoDbSetting mongoDbSetting)
        {
            _mongoDbSetting = mongoDbSetting;
        }

        public IOperation<User> GetRepository(DbType dbType)
        {
            if (dbType == DbType.SqlServer)
            {
                if (_dbContext == null)
                {
                    _dbContext = new SqlServerDbContext();
                }

                return new DbFactory<SqlServerDbContext, User>(_dbContext).GetDb(dbType);
            }
            else if (dbType == DbType.MongoDB)
            {
                return new DbFactory<SqlServerDbContext, User>(_mongoDbSetting).GetDb(dbType);
            }
            else
            {
                throw new NotImplementedException("Undefined DB provider");
            }
        }
    }
}