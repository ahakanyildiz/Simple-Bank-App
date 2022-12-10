using AHY.BankApp.Web.Data.Entities;

namespace AHY.BankApp.Web.Data.Interfaces
{
    public interface IAccountRepository
    {
        public void Create(Account user);
    }
}
