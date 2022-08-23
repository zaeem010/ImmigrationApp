using ImmigrationApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Controllers
{
    public class AccountController : Controller
    {
        public ApplicationDbContext _db;
        public AccountController(ApplicationDbContext db)
        {
            _db = db;
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
    }
}
