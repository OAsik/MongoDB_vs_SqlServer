using DbComparison.DataLayer.Base;

namespace DbComparison.ProjectLayer.Repository.Base
{
    public interface IUserRepository<T> where T : class
    {
        IOperation<T> GetRepository(DbType dbType);
    }
}