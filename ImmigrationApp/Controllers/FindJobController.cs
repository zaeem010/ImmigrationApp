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
        [Route("/Find-a-job/{Alpha}")]
        public async Task<IActionResult> JobFind()
        {
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
            var VM = new SearchjobVM
            {
                JobDTOList = JobList,
                JobTypeList = await _db.JobType.ToListAsync(),
                HomeDTO = new HomeDTO(),
            };
            return View(VM);
        }
        //
        [AllowAnonymous]
        [Route("/Find-a-jobs/{Key}")]
        [Obsolete]
        public async Task<IActionResult> JobFinds(HomeDTO HomeDTO, string Key)
        {
            var JobList = new List<JobDTO>();
            if (HomeDTO != null)
            {
                var predicate = PredicateBuilder.True<Job>();
                if (!string.IsNullOrEmpty(HomeDTO.citystate))
                {
                    predicate = predicate.And(c => c.Street.Contains(HomeDTO.citystate));
                }
                if (!string.IsNullOrEmpty(HomeDTO.category))
                {
                    predicate = predicate.And(c => c.Title.Contains(HomeDTO.category));
                }
                if (!string.IsNullOrEmpty(HomeDTO.category))
                {
                    predicate = predicate.Or(c => c.JobSubCategoryId.ToString().Contains(HomeDTO.category));
                }
                var firstlist = await _db.Job.Where(predicate).ToListAsync();
                foreach (var x in firstlist)
                {
                    JobList.Add(new JobDTO
                    {
                        Id = x.Id,
                        logoPath = _db.CompanyInfo.Where(z => z.Id.Equals(x.CompanyInfoId)).Select(z => z.LogoPath).FirstOrDefault(),
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
                    });
                }
            }
            else
            {
                JobList = await (from x in _db.Job
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
            }
            var VM = new SearchjobVM
            {
                JobDTOList = JobList,
                JobTypeList = await _db.JobType.ToListAsync(),
                HomeDTO = HomeDTO,
                Key = Key
            };
            return View("JobFind", VM);
        }
        //
        [AllowAnonymous]
        [Obsolete]
        public async Task<JsonResult> searchjob(SearchDTO SearchDTO)
        {
            var predicate = PredicateBuilder.True<Job>();
            
            if (!string.IsNullOrEmpty(SearchDTO.Title))
            {
                predicate = predicate.And(c => c.Title.Contains(SearchDTO.Title));
            }
            if (!string.IsNullOrEmpty(SearchDTO.address))
            {
                predicate = predicate.And(c => c.Street.Contains(SearchDTO.address));
            }
            if (SearchDTO.category != null && SearchDTO.category !=0)
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
            var firstlist = await _db.Job.Where(predicate).ToListAsync();
            
            var JobList = new List<JobDTO>();
            foreach (var x in firstlist)
          {
                JobList.Add(new JobDTO
                {
                    Id =x.Id,
                    logoPath =_db.CompanyInfo.Where(z=>z.Id.Equals(x.CompanyInfoId)).Select(z=>z.LogoPath).FirstOrDefault(),
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
                });
            }
            return Json(JobList);
        }
        [Route("/Apply-for-job/{slugname}/{Id}")]
        public async Task<IActionResult> JobApply(string slugname,long Id)
        {
            string check = await _db.User.Where(x => x.Id == _Cur.GetUserId()).Select(x => x.Type).FirstOrDefaultAsync();
            if (check == "Employee")
            {

            }
            return View();
        }
        
        public async Task<IActionResult> Getstatus(string term)
        {
            string url = "";
            if (term == "Web Profile")
            {
                url = "/Candidate/Profile-View/"+ await _db.CustomResume.Where(x => x.UserId == _Cur.GetUserId()).Select(x => x.SlugName).FirstOrDefaultAsync();
            }
            if (term == "Resume")
            {
                url = "/Upload/"+ await _db.CustomResume.Where(x => x.UserId == _Cur.GetUserId()).Select(x => x.ResumeUrlPath).FirstOrDefaultAsync();
            }
            return Json(url);
        }
    }
}
