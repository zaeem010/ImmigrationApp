using ImmigrationApp.Constant;
using ImmigrationApp.Data;
using ImmigrationApp.Models;
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
    public class AccountController : BaseController
    {
        public ApplicationDbContext _db;
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly ILogger<AccountController> _logger;
        public AccountController(ApplicationDbContext db,
            ILogger<AccountController> logger,
           SignInManager<IdentityUser<int>> signInManager,
           UserManager<IdentityUser<int>> userManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
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
        [HttpPost]
        public async Task<IActionResult> Register(UserDto UserDto, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var check = await _userManager.FindByEmailAsync(UserDto.Email);
                if (check == null)
                {
                    var user = new User
                    {
                        FirstName = UserDto.FirstName,
                        LastName = UserDto.LastName,
                        UserName = UserDto.Email,
                        Email = UserDto.Email,
                        Created = DateTime.Now,
                        Contact = UserDto.Contact,
                        IsActive = UserDto.IsActive,
                        Country = UserDto.Country,
                        Company = UserDto.Company,
                        Type = UserDto.Type,
                        NumberOfEmployee = UserDto.NumberOfEmployee,
                    };
                    var result = await _userManager.CreateAsync(user, UserDto.Password);
                    await _userManager.AddToRoleAsync(user, Roles.Employeer.ToString());
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        AddNotificationToView("An Error Occured While Creating The Account", false);
                        return View(UserDto);
                    }
                }
                else
                {
                    AddNotificationToView("The User With This Email Already Exists.", false);
                    return View(UserDto);
                }
            }
            return View();
        }
    }
}
