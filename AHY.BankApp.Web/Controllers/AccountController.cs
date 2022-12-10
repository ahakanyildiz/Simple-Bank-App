using AHY.BankApp.Web.Data.Entities;
using AHY.BankApp.Web.Data.UnitOfWork;
using AHY.BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AHY.BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        //private readonly BankContext _context;
        //private readonly IApplicationUserRepository _applicationUserRepository;
        //private readonly IUserMapper _userMapper;
        //private readonly IAccountRepository _accountRepository;
        //private readonly IAccountMapper _accountMapper;
        //public AccountController(BankContext context, IApplicationUserRepository applicationUserRepository, IUserMapper userMapper, IAccountRepository accountRepository, IAccountMapper accountMapper)
        //{
        //    _context = context;
        //    _applicationUserRepository = applicationUserRepository;
        //    _userMapper = userMapper;
        //    _accountRepository = accountRepository;
        //    _accountMapper = accountMapper;
        //}

        //private readonly IGenericRepository<Account> _accountRepository;
        //private readonly IGenericRepository<ApplicationUser> _userRepository;

        //public AccountController(IGenericRepository<Account> accountRepository, IGenericRepository<ApplicationUser> userRepository)
        //{
        //    _accountRepository = accountRepository;
        //    _userRepository = userRepository;
        //}

        private readonly IUow _uow;

        public AccountController(IUow uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var userInfo = _uow.GetRepository<ApplicationUser>().GetById(id);
            return View(new UserListModel
            {
                Id = userInfo.Id,
                Name = userInfo.Name,
                Surname = userInfo.Surname,
            });
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel accountCreateModel)
        {
            _uow.GetRepository<Account>().Create(new Account
            {
                AccountNumber = accountCreateModel.AccountNumber,
                Balance = accountCreateModel.Balance,
                ApplicationUserId = accountCreateModel.ApplicationUserId,
            });
            _uow.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetAccountsByUserId(int userId)
        {
            var query = _uow.GetRepository<Account>().GetQueryable();
            var accountList = query.Where(x => x.ApplicationUserId == userId).ToList();
            var user = _uow.GetRepository<ApplicationUser>().GetById(userId);
            var list = new List<AccountListModel>();



            ViewBag.fullName = user.Name + " " + user.Surname;

            foreach (var item in accountList)
            {
                list.Add(new()
                {
                    AccountNumber = item.AccountNumber,
                    ApplicationUserId = item.ApplicationUserId,
                    Balance = item.Balance,
                    Id = item.Id,
                });
            }
            return View(list);
        }

        [HttpGet]
        public IActionResult SendMoney(int accountId)
        {
            var query = _uow.GetRepository<Account>().GetQueryable();

            var accounts = query.Where(x => x.Id != accountId).ToList();

            var list = new List<AccountListModel>();

            foreach (var item in accounts)
            {
                list.Add(new()
                {
                    AccountNumber = item.AccountNumber,
                    Balance = item.Balance,
                    ApplicationUserId = item.ApplicationUserId,
                    Id = item.Id
                });
            }
            ViewBag.SenderId = accountId;
            var selectList = new SelectList(list, "Id", "AccountNumber");
            var itemList = selectList.Items;
            return View(selectList);
        }

        [HttpPost]
        public IActionResult SendMoney(SendMoneyModel sendMoneyModel)
        {
            //Unit Of Work
            var senderAccount = _uow.GetRepository<Account>().GetById(sendMoneyModel.SenderId);
            var receiverAccount = _uow.GetRepository<Account>().GetById(sendMoneyModel.AccountId);
            senderAccount.Balance -= sendMoneyModel.Amount;
            receiverAccount.Balance += sendMoneyModel.Amount;
            _uow.GetRepository<Account>().Update(senderAccount);
            _uow.GetRepository<Account>().Update(receiverAccount);
            _uow.SaveChanges();
            return RedirectToAction("GetAccountsByUserId", new { userId = senderAccount.ApplicationUserId });
        }
    }
}
