using ImmigrationApp.Currentuser;
using ImmigrationApp.Data;
using ImmigrationApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Controllers
{
    public class FindJobController : Controller
    {
        private ApplicationDbContext _db { get; set; }
        private ICurrentuser _Cur { get; set; }
        
        public FindJobController(ICurrentuser Cur, ApplicationDbContext db)
        {
            _db = db;
            _Cur = Cur;
        }
        [AllowAnonymous]
        [Route("/Find-a-job")]
        public async Task<IActionResult> JobFind()
        {
            var JobList = await(from x in _db.Job
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
                                }).ToListAsync();
            return View(JobList);
        }
    }
}
