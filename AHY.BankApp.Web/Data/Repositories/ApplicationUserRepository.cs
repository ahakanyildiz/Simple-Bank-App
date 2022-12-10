using AHY.BankApp.Web.Data.Context;
using AHY.BankApp.Web.Data.Entities;
using AHY.BankApp.Web.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AHY.BankApp.Web.Data.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly BankContext _context;

        public ApplicationUserRepository(BankContext context)
        {
            _context = context;
        }

        public void Create(ApplicationUser user)
        {
            _context.Set<ApplicationUser>().Add(user);
            _context.SaveChanges();
        }

        public List<ApplicationUser> GetAll()
        {
            return _context.Set<ApplicationUser>().ToList();
        }


        public ApplicationUser GetById(int id)
        {
            return _context.Set<ApplicationUser>().SingleOrDefault(x=>x.Id==id);
        }

        public void Remove(ApplicationUser user)
        {
            _context.Set<ApplicationUser>().Remove(user);
            _context.SaveChanges();
        }
    }
}
