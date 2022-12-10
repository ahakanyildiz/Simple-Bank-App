using AHY.BankApp.Web.Data.Entities;
using AHY.BankApp.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace AHY.BankApp.Web.Mapping
{
    public class UserMapper : IUserMapper
    {
        public List<UserListModel> MapToListOfUserList(List<ApplicationUser> users)
        {
            return users.Select(x => new UserListModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname
            }).ToList();
        }

        public UserListModel MapToUserList(ApplicationUser user)
        {
            return new UserListModel
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname
            };
        }
    }
}
