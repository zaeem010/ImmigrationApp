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
        public JobPostController(IJobPostRepository job)
        {
            _job = job;
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
                //Job = new Job()
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
