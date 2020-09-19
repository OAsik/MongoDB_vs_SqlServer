using System;
using DbComparison.DataLayer.Base;
using DbComparison.DataLayer.MongoDB;
using DbComparison.DataLayer.MongoDB.Setting.Base;
using DbComparison.DataLayer.SqlServer;

namespace DbComparison.DataLayer.Factory
{
    public class DbFactory<C, T> where C : BaseDataContext where T : class
    {
        public C _baseDataContext;
        public IMongoDbSetting _mongoDbSetting;

        public DbFactory(IMongoDbSetting mongoDbSetting)
        {
            _mongoDbSetting = mongoDbSetting;
        }

        public DbFactory(C baseDataContext)
        {
            _baseDataContext = baseDataContext;
        }

        public IOperation<T> GetDb(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.SqlServer:
                    return new SqlServerRepositoryBase<C, T>(_baseDataContext);
                case DbType.MongoDB:
                    return new MongoDbRepositoryBase<T>(_mongoDbSetting);
                default:
                    throw new ArgumentOutOfRangeException(nameof(dbType), "Undefined DB provider");
            }
        }
    }
}