using ImmigrationApp.Currentuser;
using ImmigrationApp.Data;
using ImmigrationApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
            var CompanyList = await _db.CompanyInfo
                .Include(c => c.JobList)
                .ToListAsync();
            var JobList = await (from x in _db.Job
                                 select new JobDTO
                                 {
                                     Id = x.Id,
                                     logoPath = _db.CompanyInfo.Where(c => c.Id.Equals(x.CompanyInfoId)).Select(a => a.LogoPath).FirstOrDefault(),
                                     Title = x.Title,
                                     SpecificAddress = x.SpecificAddress,
                                     Street = x.Street,
                                     City = x.City,
                                     Province = x.Province,
                                     PostalCode = x.PostalCode,
                                     AddressToAdvertise = x.AddressToAdvertise,
                                     ShowBy = x.ShowPayby,
                                     MinPay = x.MinPay,
                                     MaxPay = x.MaxPay,
                                     Amount = x.Amount,
                                     Rate = x.Rate,
                                     SlugName = x.SlugName,
                                     PostDateTime = x.PostDateTime,
                                     CallBy = x.CallBy,
                                 }).ToListAsync();

            var VM = new HomeVM
            {
                CompanyInfoList = CompanyList,
                JobList = JobList,
                UserId = _Cur.GetUserId(),
            };
            return View(VM);
        }
        [HttpGet]
        [Route("/Home/GetData_1")]
        public async Task<JsonResult> GetData_1(string term)
        {
            var data = await _db.Cities.Where(c => c.cityregion.Contains(term)).Distinct().ToListAsync();
            return Json(data);
        }
        [HttpGet]
        [Route("/Home/GetData_2")]
        public async Task<JsonResult> GetData_2(string term)
        {
            var data = await _db.Job.Where(c => c.Title.Contains(term)).Distinct().ToListAsync();
            return Json(data);
        }
        [HttpGet]
        [Route("/Companies")]
        public async Task<IActionResult> Companies()
        {
            var companys = await _db.CompanyInfo
               .Include(c => c.JobList)
               .Include(c => c.JobMainCategory)
               .ToListAsync();
            return View(companys);
        }
        [Route("/About")]
        public IActionResult About()
        {
            return View();
        }
        [Route("/FAQ")]
        public IActionResult FAQ()
        {
            return View();
        }
        public IActionResult AllStates()
        {
            return View();
        }

        public async Task<IActionResult> GetStates(IFormCollection form)
        {
            var Request = form["myRequest"];
            var States = Newtonsoft.Json.JsonConvert.DeserializeObject<List<States>>(Request);

            await _db.States.AddRangeAsync(States);
            await _db.SaveChangesAsync();
            return Ok();
        }
        public async Task<IActionResult> Getcity(IFormCollection form)
        {
            var Request = form["myRequest"];
            var Cities = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cities>>(Request);

            await _db.Cities.AddRangeAsync(Cities);
            await _db.SaveChangesAsync();
            return Ok();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
