using System.Collections.Generic;

namespace AHY.BankApp.Web.Data.Entities
{
    public class ApplicationUser : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
