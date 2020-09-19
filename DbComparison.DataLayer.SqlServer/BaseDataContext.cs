using System;
using DbComparison.DataLayer.Base;
using Microsoft.EntityFrameworkCore;

namespace DbComparison.DataLayer.SqlServer
{
    public class BaseDataContext : DbContext, IDisposable, IBaseDataContext
    {
        public string DatabaseName { get; private set; }

        private void Initialize()
        {
            DatabaseName = base.Database.GetDbConnection().Database;
        }

        protected BaseDataContext()
        {
            Initialize();
        }

        protected BaseDataContext(DbContextOptions options) : base(options)
        {
            Initialize();
        }
    }
}