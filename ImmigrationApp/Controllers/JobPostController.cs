using ImmigrationApp.Currentuser;
using ImmigrationApp.Models;
using ImmigrationApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Controllers
{
    public class JobPostController : BaseController
    {
        private IJobPostRepository _job { get; set; }
        private ICurrentuser _Cur { get; set; }
        public JobPostController(ICurrentuser Cur, IJobPostRepository job)
        {
            _job = job;
            _Cur = Cur;
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
            return View(VM);
        }
        [Route("/Job/Save")]
        public async Task<JsonResult> Save(Job Job)
        {
            var result = await _job.SaveJob(Job);
            return Json(result);
        }

    }
}
