using ImmigrationApp.Currentuser;
using ImmigrationApp.Data;
using ImmigrationApp.Models;
using LinqKit;
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
            var VM = new SearchjobVM
            {
                JobDTOList=JobList,
                JobTypeList =await _db.JobType.ToListAsync(),
            };
            return View(VM);
        }
        [AllowAnonymous]
        [Obsolete]
        public async Task<IActionResult> searchjob(SearchDTO SearchDTO)
        {
            var predicate = PredicateBuilder.True<Job>();
            if (!string.IsNullOrEmpty(SearchDTO.Title))
            {
                predicate = predicate.And(c => c.Title.Contains(SearchDTO.Title));
            }
            if (!string.IsNullOrEmpty(SearchDTO.category))
            {
                predicate = predicate.And(c => c.JobSubCategoryId.Equals(SearchDTO.category));
            }
            if (SearchDTO.types != null)
            {
                string[] _type = new string[] { };
                foreach (var type in SearchDTO.types)
                {
                    if (!string.IsNullOrEmpty(type.ToString()))
                    {
                        _type = _type.Concat(new string[] { type.ToString() }).ToArray();
                    }
                }
                predicate = predicate.And(c => c.JobTypeChildList.Any(z => _type.Contains(z.JobTypeId.ToString())));
            }
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
                                 }).ToListAsync();
            return View();
        }
        [Route("/Apply-for-job/{slugname}")]
        public async Task<IActionResult> JobApply(string slugname)
        {
            return View(slugname);
        }

    }
}
