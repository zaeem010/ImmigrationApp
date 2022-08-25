using ImmigrationApp.Currentuser;
using ImmigrationApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Controllers
{
    public class EmployerController : Controller
    {
        public ApplicationDbContext _db { get; set; }
        public ICurrentuser _Currentuser { get; set; }
        public EmployerController(ICurrentuser Currentuser, ApplicationDbContext db)
        {
            _db = db;
            _Currentuser = Currentuser;
        }
        [Route("/Employer/Dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            var CompanyInfo = await _db.CompanyInfo.SingleOrDefaultAsync(c=>c.UserId.Equals(_Currentuser.GetUserId()));
            return View(CompanyInfo);
        }
        [Route("/Employer/Profile")]
        public async Task<IActionResult> Profile()
        {
            var CompanyInfo = await _db.CompanyInfo.SingleOrDefaultAsync(c=>c.UserId.Equals(_Currentuser.GetUserId()));
            IEnumerable<SelectListItem> Country = _db.Country.Select(c=>new SelectListItem
            {
                Value= c.CountryName,
                Text= c.CountryName,
            });
            return View(CompanyInfo);
        }
    }
}
