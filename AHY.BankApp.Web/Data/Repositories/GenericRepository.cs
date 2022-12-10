using AHY.BankApp.Web.Data.Context;
using AHY.BankApp.Web.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AHY.BankApp.Web.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        private readonly BankContext _context;

        public GenericRepository(BankContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> GetQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

    }
}
