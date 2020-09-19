using System;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;
using System.Collections.Generic;
using DbComparison.DataLayer.Base;
using DbComparison.DataLayer.MongoDB.Setting;
using DbComparison.DataLayer.MongoDB.Setting.Base;

namespace DbComparison.DataLayer.MongoDB
{
    public class MongoDbRepositoryBase<T> : IOperation<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public MongoDbRepositoryBase(IMongoDbSetting settings)
        {
            IMongoDatabase database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<T>(GetCollectionName(typeof(T)));
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault())?.CollectionName;
        }

        public T Insert(T entity)
        {
            _collection.InsertOne(entity);

            return entity;
        }

        public List<T> InsertRange(List<T> entityList)
        {
            _collection.InsertMany(entityList);

            return entityList;
        }

        public T GetSingle(Guid id)
        {
            throw new NotImplementedException();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, Guid id = new Guid())
        {
            return _collection.Find(predicate).FirstOrDefault();
        }

        public List<T> GetAll()
        {
            return _collection.Find(Builders<T>.Filter.Empty).ToList();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        public T Update(Expression<Func<T, bool>> predicate, T entity)
        {
            _collection.FindOneAndReplace(predicate, entity);

            return entity;
        }

        public bool Delete(Guid id)
        {
            string objectId = id.ToString();

            ObjectId bsonId = new ObjectId(objectId);

            //Hardcoding field name is not recommended in real life projects. Instead, derive all your entities from an interface which contains all the common fields among your entities (e.g. primary key field, or creation date etc.). And then, change IOperation's generic type to that interface instead of class reference type. Finally, you can reach that common field on .Eq function like (x => x.<your common field name>, bsonId) --Özgür
            var filter = Builders<T>.Filter.Eq("UserId", bsonId);

            _collection.FindOneAndDelete(filter);

            return true;
        }

        public bool DeleteRange(List<Guid> idList)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRange(Expression<Func<T, bool>> predicate)
        {
            _collection.DeleteMany(predicate);

            return true;
        }
    }
}