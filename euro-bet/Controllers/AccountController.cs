using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using euro_bet.Models;
using euro_bet.Data;


namespace euro_bet.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly EuroBetContext _dbContext;

        public AccountController(ILogger<AccountController> logger, EuroBetContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            HttpContext.Session.SetString("username",username);
            return View();
        }

        [Route("Signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("Signup")]
        [HttpPost]
        public IActionResult Signup(string firstName, string middleName, string lastName)
        {
            SignupViewModel model = new SignupViewModel();
            model.FirstName = firstName;
            model.MiddleName = middleName;
            model.LastName = lastName;

            TempData["model"] = model;
            return View("Signup2", model);
        }

        [Route("Signup2")]
        public IActionResult Signup2( SignupViewModel model)
        {
            TempData["model"] = model;
            return View();
        }

        [Route("Signup2")]
        [HttpPost]
        public IActionResult Signup2(string email, string phone, string country, string state, string city)
        {
            SignupViewModel model = (SignupViewModel)TempData["model"];
            model.Email = email;
            model.Phone = phone;
            model.Address = string.Format("{0}, {1}, {2}", city, state, country);
            ViewData["model"] = model;
            return View("Signup3", model);
        }

        [Route("Signup3")]
        public IActionResult Signup3(SignupViewModel model)
        {
            ViewData["model"] = model;
            return View();
        }

        [Route("Signup3")]
        [HttpPost]
        public IActionResult Signup3(string userName, string password)
        {
            SignupViewModel model = (SignupViewModel)ViewData["model"];
            model.UserName = userName;
            model.Password = password;
            ViewData["model"] = model;
            return View("Signup4", model);
        }

        [Route("Signup4")]
        public IActionResult Signup4(SignupViewModel model)
        {
            ViewData["model"] = model;
            return View(model);
        }

        [Route("Signup4")]
        [HttpPost]
        public IActionResult Signup4()
        {
            SignupViewModel model = (SignupViewModel)ViewData["model"];
            //save
            Account newAccount = new Account();
            newAccount.UserName = model.UserName;
            newAccount.Password = model.Password;
            newAccount.DateCreated = DateTime.Now;
            newAccount.IsActive = false;
            //_dbContext.Account.Add(newAccount);

            Contact newContact = new Contact();
            newContact.Email = model.Email;
            newContact.Phone = model.Phone;
            newContact.Address = model.Address;
            //_dbContext.Contact.Add(newContact);

            User newUser = new User();
            newUser.FirstName = model.FirstName;
            newUser.MiddleName = model.MiddleName;
            newUser.LastName = model.LastName;
            newUser.Account = newAccount;
            newUser.Contact = newContact;
            _dbContext.User.Add(newUser);

            _dbContext.SaveChanges();

            return View("Login");
        }

        [Route("Profile")]
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Denied()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
