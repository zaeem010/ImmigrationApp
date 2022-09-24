using ImmigrationApp.Currentuser;
using ImmigrationApp.Data;
using ImmigrationApp.Models;
using ImmigrationApp.Repositries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Controllers
{
    public class JobPostController : BaseController
    {
        private IJobPostRepository _job { get; set; }
        private ApplicationDbContext _db { get; set; }
        private ICurrentuser _Cur { get; set; }
        public JobPostController(ApplicationDbContext db, ICurrentuser Cur, IJobPostRepository job)
        {
            _job = job;
            _Cur = Cur;
            _db = db;
        }
        [Route("/Job/Post-a-Job")]
        public async Task<IActionResult> JobPost()
        {
            var VM = new JobVM
            {
                JobTypeList = await _job.GetJobType(),
                JobScheduleList=await _job.GetJobSchedule(),
                SupplementalPayList=await _job.GetSupplementalPay(),
                BenefitOfferedList=await _job.GetBenefitOffered(),
                UserId = _Cur.GetUserId(),
                CompanyId = await _job.GetCompanyId(_Cur.GetUserId()),
            };
            if (VM.CompanyId != 0)
            {
                return View(VM);
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
            
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("/Job/Gettitle")]
        public async Task<IActionResult> Gettitle(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                var states = await _db.JobSubCategory.ToListAsync();
                var data = states.Where(c => c.Name.Contains(term, StringComparison.OrdinalIgnoreCase)).ToList().AsReadOnly();
                return Ok(data);
            }
            else
            {
                return Ok();
            }
        }
        [Route("/Job/Save")]
        public async Task<JsonResult> Save(Job Job)
        {
            var result = await _job.SaveJob(Job);
            return Json(result);
        }
        [Route("/Job/Manage-Jobs")]
        public async Task<IActionResult> ManageJobs()
        {
            var result = await _job.GetAllJob(_Cur.GetUserId());
            return View(result);
        }
        [Route("/Job/Update-Job")]
        public async Task<IActionResult> UpdateJob(long Id)
        {
            var VM = new JobVM
            {
                Job = await _job.GetJob(Id),
                JobTypeList = await _job.GetJobType(),
                JobScheduleList = await _job.GetJobSchedule(),
                SupplementalPayList = await _job.GetSupplementalPay(),
                BenefitOfferedList = await _job.GetBenefitOffered(),
                UserId = _Cur.GetUserId(),
                CompanyId = await _job.GetCompanyId(_Cur.GetUserId()),
            };
            return View("JobPost", VM);
        }
        [AllowAnonymous]
        [Route("/Job/Job-Detail/{SlugName}")]
        public async Task<IActionResult> JobDetail(string SlugName)
        {
            var result = await (from x in _db.Job
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
                                     PostDateTime = x.PostDateTime,
                                     Vacant = x.Numberofvaccant,
                                     StartDate = x.StartDate,
                                     Description = x.Description,
                                     SlugName = x.SlugName,
                                     Industry = x.JobSubCategory.Name,
                                     jobTypes =x.JobTypeChildList
                                 })
                                 .SingleOrDefaultAsync(x=>x.SlugName == SlugName);
            var VM = new JobDetailVM {
            JobDTO=result,
            JobTypeList =await _db.JobType.ToListAsync()
            };
            return View(VM);
        }
        
    }
}
