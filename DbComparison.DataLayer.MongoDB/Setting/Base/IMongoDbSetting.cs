using System;

namespace DbComparison.DataLayer.MongoDB.Setting.Base
{
    public interface IMongoDbSetting
    {
        string DatabaseName { get; set; }

        string ConnectionString { get; set; }
    }
}