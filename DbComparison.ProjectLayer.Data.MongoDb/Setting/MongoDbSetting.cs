using DbComparison.DataLayer.MongoDB.Setting.Base;

namespace DbComparison.ProjectLayer.Data.MongoDb.Setting
{
    public class MongoDbSetting : IMongoDbSetting
    {
        public string DatabaseName { get; set; }

        public string ConnectionString { get; set; }
    }
}