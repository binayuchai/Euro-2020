using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using euro_bet.Models;
using euro_bet.Data;
using euro_bet.Services;
using Microsoft.AspNetCore.Authorization;

namespace euro_bet.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly EuroBetContext _dbContext;
        private readonly AuthService _authService;

        public AccountController(ILogger<AccountController> logger, EuroBetContext context)
        {
            _logger = logger;
            _dbContext = context;
            _authService = new AuthService();
        }

        [Route("Login")]

        public IActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(string username, string password, string returnUrl = null)
        {
            
            var userAccount = _dbContext.Account.FirstOrDefault(x=> x.UserName.ToLower() == username.ToLower());
            if(userAccount!=null)
            {
                var hashedPassword = userAccount.Password;
                var isValid = _authService.VerifyPassword(hashedPassword, password);
                if(isValid)
                {
                    var user = _dbContext.User.FirstOrDefault(x=> x.Account.AccountID == userAccount.AccountID);
                    var role="User";
                    if(username=="sthakuri" || username =="buchai")
                    {
                        role="Admin";
                    }
                    var claims = new List<Claim>
                    {
                        new Claim("username", username),
                        new Claim("displayname", string.Format("{0} {1}", user.FirstName, user.LastName )),
                        new Claim("role", role)
                    };

                    await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "user", "role")));

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return Redirect("/");
                    }
                }
                else
                {
                    ViewBag.Error="Invalid password.";
                }
            }
            // else if(!userAccount.IsActive)
            // {
            //     ViewBag.Error="Username is not active.";
            // }
            else
            {
                ViewBag.Error="Username does not exist.";
            }
            return View();
        }

        [Route("Logout")]

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
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

            TempData["model"] = JsonConvert.SerializeObject(model);
            return View("Signup2", model);
        }

        [Route("Signup2")]
        public IActionResult Signup2(SignupViewModel model)
        {
            TempData["model"] = JsonConvert.SerializeObject(model);
            return View();
        }

        [Route("Signup2")]
        [HttpPost]
        public IActionResult Signup2(string email, string phone, string country, string state, string city)
        {
            // Verify phone
            var chk = _dbContext.Contact.Any(x=> x.Phone.ToLower() == phone.ToLower());
            if(chk)
            {
                ViewBag.Error = "Phone already exist, please contact admin to recover password.";
                return View();
            }
            else
            {
                object o;
                TempData.TryGetValue("model", out o);
                SignupViewModel model= (o == null) ? new SignupViewModel() : JsonConvert.DeserializeObject<SignupViewModel>((string)o);
                //SignupViewModel model = JsonConvert.DeserializeObject<SignupViewModel>(TempData["model"].ToString());
                model.Email = email;
                model.Phone = phone;
                model.Address = string.Format("{0}, {1}, {2}", city, state, country);
                TempData["model"] = JsonConvert.SerializeObject(model);
                ViewBag.Phone = model.Phone;
                return View("Signup3", model);
            }
        }

        [Route("Signup3")]
        public IActionResult Signup3(SignupViewModel model)
        {
            TempData["model"] = JsonConvert.SerializeObject(model);
            return View();
        }

        [Route("Signup3")]
        [HttpPost]
        public IActionResult Signup3(string username, string password)
        {
            object o;
            TempData.TryGetValue("model", out o);
            SignupViewModel model= (o == null) ? new SignupViewModel() : JsonConvert.DeserializeObject<SignupViewModel>((string)o);
                
            // Verify username
            username = model.Phone; //phone is set as username

            var chk = _dbContext.Account.Any(x=> x.UserName.ToLower() == username.ToLower());
            if(chk)
            {
                ViewBag.Error = "Username already exist, please try another.";
                return View();
            }
            else
            {
                
                //save
                Account newAccount = new Account();
                newAccount.UserName = username;

                newAccount.Password = _authService.HashPassword(password);
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

                return View("Signup4");
            }
        }

        [Route("Signup4")]
        public IActionResult Signup4()
        {
            return View();
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Users()
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
