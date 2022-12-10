using AHY.BankApp.Web.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AHY.BankApp.Web.Data.Repositories
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        public void Create(T entity);
        public List<T> GetAll();
        public T GetById(object id);
        public void Remove(T entity);
        public void Update(T entity);
        IQueryable<T> GetQueryable();
    }
}
