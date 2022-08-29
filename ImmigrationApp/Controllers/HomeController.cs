using ImmigrationApp.Currentuser;
using ImmigrationApp.Data;
using ImmigrationApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db { get; set; }
        private ICurrentuser _Cur { get; set; }
        public HomeController(ICurrentuser Cur, ApplicationDbContext db, ILogger<HomeController> logger)
        {
            _db = db;
            _Cur = Cur;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var CompanyList = await _db.CompanyInfo.ToListAsync();
            var VM = new HomeVM
            {
                CompanyInfoList=CompanyList,
                UserId=_Cur.GetUserId(),
            };
            return View(VM);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
