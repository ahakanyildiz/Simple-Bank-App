using AHY.BankApp.Web.Data.Context;
using AHY.BankApp.Web.Data.Entities;
using AHY.BankApp.Web.Data.Repositories;

namespace AHY.BankApp.Web.Data.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly BankContext _context;

        public Uow(BankContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GetRepository<T>() where T : class, IEntity, new()
        {
            return new GenericRepository<T>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
