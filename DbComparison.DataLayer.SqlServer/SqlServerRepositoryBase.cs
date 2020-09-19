using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using DbComparison.DataLayer.Base;
using Microsoft.EntityFrameworkCore;

namespace DbComparison.DataLayer.SqlServer
{
    public class SqlServerRepositoryBase<C, T> : IOperation<T> where C : BaseDataContext where T : class
    {
        protected DbSet<T> _dbSet { get; set; }

        protected C _dataContext { get; private set; }

        public SqlServerRepositoryBase(C dataContext)
        {
            _dataContext = dataContext;

            _dbSet = _dataContext.Set<T>();
        }

        public T Insert(T entity)
        {
            _dbSet.Add(entity);

            _dataContext.SaveChanges();

            return entity;
        }

        public List<T> InsertRange(List<T> entityList)
        {
            _dbSet.AddRange(entityList);

            _dataContext.SaveChanges();

            return entityList;
        }

        public T GetSingle(Guid id)
        {
            return _dbSet.Find(id);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, Guid id = new Guid())
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public List<T> GetAll()
        {
            return _dbSet.AsEnumerable().ToList();
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);

            _dataContext.SaveChanges();

            return entity;
        }

        public T Update(Expression<Func<T, bool>> predicate, T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            T entity = _dbSet.Find(id);

            _dbSet.Remove(entity);

            _dataContext.SaveChanges();

            return true;
        }

        public bool DeleteRange(List<Guid> idList)
        {
            List<T> entityList = new List<T>();

            foreach (Guid id in idList)
            {
                T entity = _dbSet.Find(id);

                entityList.Add(entity);
            }

            _dbSet.RemoveRange(entityList);

            _dataContext.SaveChanges();

            return true;
        }

        public bool DeleteRange(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}