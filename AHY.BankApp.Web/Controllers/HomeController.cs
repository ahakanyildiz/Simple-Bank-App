using AHY.BankApp.Web.Data.Entities;
using AHY.BankApp.Web.Data.UnitOfWork;
using AHY.BankApp.Web.Mapping;
using Microsoft.AspNetCore.Mvc;


namespace AHY.BankApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserMapper _userMapper;
        private readonly IUow _uow;
        public HomeController(IUserMapper userMapper, IUow uow)
        {
            _userMapper = userMapper;
            _uow = uow;
        }

        public IActionResult Index()
        {
            return View(_userMapper.MapToListOfUserList(_uow.GetRepository<ApplicationUser>().GetAll()));
        }
    }
}
