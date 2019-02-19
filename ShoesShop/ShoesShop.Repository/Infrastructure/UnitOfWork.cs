using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ShoesShop.Repository.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreManagementEntities _dbContext;

        public UnitOfWork()
        {
            _dbContext = new StoreManagementEntities();
            //_dbContext.SaveChanges();
        }

        public DbContext Db
        {
            get { return _dbContext; }
        }

     
        public void Dispose()
        {
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }

}
