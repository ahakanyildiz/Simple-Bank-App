using AHY.BankApp.Web.Data.Entities;
using System.Collections.Generic;

namespace AHY.BankApp.Web.Data.Interfaces
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUser> GetAll();
        ApplicationUser GetById(int id);
        public void Create(ApplicationUser user);
    }
}
