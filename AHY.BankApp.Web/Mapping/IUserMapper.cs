using AHY.BankApp.Web.Data.Entities;
using AHY.BankApp.Web.Models;
using System.Collections.Generic;

namespace AHY.BankApp.Web.Mapping
{
    public interface IUserMapper
    {
        List<UserListModel> MapToListOfUserList(List<ApplicationUser> users);
        UserListModel MapToUserList(ApplicationUser user);
    }
}
