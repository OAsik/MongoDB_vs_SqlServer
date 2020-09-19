using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace DbComparison.DataLayer.Base
{
    public interface IOperation<T> where T : class
    {
        T Insert(T entity);

        List<T> InsertRange(List<T> entityList);

        T GetSingle(Guid id);
        T GetSingle(Expression<Func<T, bool>> predicate, Guid id = new Guid());

        List<T> GetAll();

        T Update(T entity);
        T Update(Expression<Func<T, bool>> predicate, T entity);

        bool Delete(Guid id);

        bool DeleteRange(List<Guid> idList);
        bool DeleteRange(Expression<Func<T, bool>> predicate);
    }
}