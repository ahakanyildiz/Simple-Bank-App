using AHY.BankApp.Web.Data.Entities;
using AHY.BankApp.Web.Data.Repositories;

namespace AHY.BankApp.Web.Data.UnitOfWork
{
    public interface IUow
    {
        public IGenericRepository<T> GetRepository<T> () where T : class,IEntity, new();
        public void SaveChanges();
    }
}