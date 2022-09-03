using ImmigrationApp.Constant;
using ImmigrationApp.Currentuser;
using ImmigrationApp.Data;
using ImmigrationApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        public ApplicationDbContext _db;
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController( ApplicationDbContext db,
            ILogger<AccountController> logger,
           SignInManager<IdentityUser<int>> signInManager,
           UserManager<IdentityUser<int>> userManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            await _signInManager.SignOutAsync();
            ViewBag.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginDTO());
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO LoginDTO, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ViewBag.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            ViewBag.ReturnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(LoginDTO.Email, LoginDTO.Password, LoginDTO.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    AddNotificationToView("Invalid login attempt.", false);
                    return View("Login", LoginDTO);
                }
            }
            return View("Login", LoginDTO);
        }
        [AllowAnonymous]
        [Route("/Account/Employer-SignUp")]
        public IActionResult EmployeeSignUp()
        {
            IEnumerable<SelectListItem> Country = _db.Country.Select(c => new SelectListItem
            {
                Value =c.CountryName,
                Text =c.CountryName,
            });
            ViewBag.Country = Country;
            return View();
        }
        [AllowAnonymous]
        [Route("/Account/Candidate-SignUp")]
        public IActionResult CandidateSignUp()
        {
            IEnumerable<SelectListItem> Country = _db.Country.Select(c => new SelectListItem
            {
                Value =c.CountryName,
                Text =c.CountryName,
            });
            ViewBag.Country = Country;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(UserDto UserDto, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                IEnumerable<SelectListItem> Country = _db.Country.Select(c => new SelectListItem
                {
                    Value = c.CountryName,
                    Text = c.CountryName,
                });
                var check = await _userManager.FindByEmailAsync(UserDto.Email);
                if (check == null)
                {
                    var user = new User
                    {
                        FirstName = UserDto.FirstName,
                        LastName = UserDto.LastName,
                        UserName = UserDto.Email,
                        Email = UserDto.Email,
                        Type = UserDto.Type,
                        Created = DateTime.Now,
                        IsActive = UserDto.IsActive,
                    };
                    var result = await _userManager.CreateAsync(user, UserDto.Password);
                    await _userManager.AddToRoleAsync(user, Roles.Employeer.ToString());
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        var GetId = await _userManager.FindByEmailAsync(UserDto.Email);
                        if (UserDto.Type == "Employee")
                        {
                            string Slugname = UserDto.Company;
                            var CompanyInfo = new CompanyInfo
                            {
                                Country = UserDto.Country,
                                Company = UserDto.Company,
                                Contact = UserDto.Contact,
                                NumberOfEmployee = UserDto.NumberOfEmployee,
                                Email = UserDto.Email,
                                SlugName = Slugname.Replace(" ", "-"),
                                UserId = GetId.Id,
                            };
                            await _db.CompanyInfo.AddAsync(CompanyInfo);
                        }
                        
                        await _db.SaveChangesAsync();
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        ViewBag.Country = Country;
                        AddNotificationToView("An Error Occured While Creating The Account", false);
                        return View("EmployeeSignUp", UserDto);
                    }
                }
                else
                {
                    ViewBag.Country = Country;
                    AddNotificationToView("The User With This Email Already Exists.", false);
                    return View("EmployeeSignUp", UserDto);
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterCanidate(UserCandidateDto UserDto, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                IEnumerable<SelectListItem> Country = _db.Country.Select(c => new SelectListItem
                {
                    Value = c.CountryName,
                    Text = c.CountryName,
                });
                var check = await _userManager.FindByEmailAsync(UserDto.Email);
                if (check == null)
                {
                    var user = new User
                    {
                        FirstName = UserDto.FirstName,
                        LastName = UserDto.LastName,
                        UserName = UserDto.Email,
                        Email = UserDto.Email,
                        Type = UserDto.Type,
                        Created = DateTime.Now,
                        IsActive = UserDto.IsActive,
                    };
                    var result = await _userManager.CreateAsync(user, UserDto.Password);
                    await _userManager.AddToRoleAsync(user, Roles.Canidate.ToString());
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        var GetId = await _userManager.FindByEmailAsync(UserDto.Email);
                            await _userManager.AddToRoleAsync(user, Roles.Canidate.ToString());
                            string Slugname = UserDto.FirstName +' '+ UserDto.LastName;
                            var Candidate = new CustomResume
                            {
                                FirstName = UserDto.FirstName,
                                LastName = UserDto.LastName,
                                Country = UserDto.Country,
                                PhoneNumber = UserDto.Contact,
                                Email = UserDto.Email,
                                SlugName = Slugname.Replace(" ", "-"),
                                UserId = GetId.Id,
                            };
                        await _db.CustomResume.AddAsync(Candidate);
                        await _db.SaveChangesAsync();
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        ViewBag.Country = Country;
                        AddNotificationToView("An Error Occured While Creating The Account", false);
                        return View("CandidateSignUp", UserDto);
                    }
                }
                else
                {
                    ViewBag.Country = Country;
                    AddNotificationToView("The User With This Email Already Exists.", false);
                    return View("CandidateSignUp", UserDto);
                }
            }
            return View();
        }
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            returnUrl ??= Url.Content("~/");
            return LocalRedirect(returnUrl);
        }
    }
}
