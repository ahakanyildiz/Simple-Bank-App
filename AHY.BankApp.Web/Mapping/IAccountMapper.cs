using AHY.BankApp.Web.Data.Entities;
using AHY.BankApp.Web.Models;

namespace AHY.BankApp.Web.Mapping
{
    public interface IAccountMapper
    {
        public Account Map(AccountCreateModel model);
    }
}