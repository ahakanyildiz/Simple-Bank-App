using AHY.BankApp.Web.Data.Entities;
using AHY.BankApp.Web.Models;

namespace AHY.BankApp.Web.Mapping
{
    public class AccountMapper : IAccountMapper
    {
        public Account Map(AccountCreateModel model)
        {
            return new Account
            {
                AccountNumber = model.AccountNumber,
                ApplicationUserId = model.ApplicationUserId,
                Balance = model.Balance,
            };
        }
    }
}
