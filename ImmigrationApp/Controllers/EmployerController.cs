using ImmigrationApp.Currentuser;
using ImmigrationApp.Data;
using ImmigrationApp.Models;
using ImmigrationApp.Repositries;
using ImmigrationApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace ImmigrationApp.Controllers
{
    public class EmployerController : BaseController
    {
        public ApplicationDbContext _db { get; set; }
        public ICompanyInfoServices _companyInfoservice { get; set; }
        public ICommonRepo _CommonRepo { get; set; }
        public ICompanyInfoRepo _companyInfo { get; set; }
        public ICurrentuser _Currentuser { get; set; }
        private readonly IWebHostEnvironment host;
        public EmployerController(ICompanyInfoRepo companyInfos, ApplicationDbContext db, ICommonRepo CommonRepo, ICurrentuser Currentuser, ICompanyInfoServices companyInfo, IWebHostEnvironment host)
        {
            _db = db;
            _companyInfo = companyInfos;
            _companyInfoservice = companyInfo;
            _CommonRepo = CommonRepo;
            _Currentuser = Currentuser;
            this.host = host;
        }
        [Route("/Employer/Dashboard")]
        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var CompanyInfo = await _companyInfo.GetSingleCompanyInfo(_Currentuser.GetUserId());
            return View(CompanyInfo);
        }
        [Route("/Employer/Profile")]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var CompanyInfo = await _companyInfo.GetSingleCompanyInfo(_Currentuser.GetUserId());
            var Country =  _CommonRepo.GetCountryList(CompanyInfo.Country);
            IEnumerable<SelectListItem> Category = _db.JobMainCategory.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
            });
            var VM = new CompanyInfoVM
            {
                CompanyInfo=CompanyInfo,
                CountryList=Country,
                JobMainCategoryList=Category
            };
            return View(VM);
        }
        [AllowAnonymous]
        [Route("/Company/Profile-View/{Slugname}/{CallBy}")]
        [HttpGet]
        public async Task<IActionResult> ViewProfile(string Slugname,string CallBy)
        {
            var CompanyInfo = await _companyInfo.GetCompanyInfoByslugName(CallBy);
            return View(CompanyInfo);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(CompanyInfo CompanyInfo)
        {
            Random r = new Random();
            int num = r.Next();
            var webrootpath = host.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            //Image Insert
            if (files.Count > 0)
            {
                var uploads = Path.Combine(webrootpath, "Upload");
                var Ext = Path.GetExtension(files[0].FileName);
                using (var stream = new FileStream(Path.Combine(uploads, num + Ext), FileMode.Create))
                {
                    files[0].CopyTo(stream);
                }
                CompanyInfo.LogoPath = num + Ext;
            }
            string Slugname = CompanyInfo.Company;
            CompanyInfo.SlugName = Slugname.Replace(" ", "-");
            _db.CompanyInfo.Update(CompanyInfo);
            await _db.SaveChangesAsync();
            AddNotificationToView("Company Profile Updated Successfully", true);
            return RedirectToAction("Profile");
        }
        [Route("/Employer/Manage-Job-Request")]
        public IActionResult ManageRequest()
        {
            var AppliedJob = (from x in _db.ApplyforJob
                              select new ApplyforJob
                              {
                                  Id = x.Id,
                                  JobId = x.JobId,
                                  CanidateId = x.CanidateId,
                                  EmployerId = x.EmployerId,
                                  CoverLetter = x.CoverLetter,
                                  AppliedUsing = x.AppliedUsing,
                                  AppliedDate = x.AppliedDate,
                                  Status = x.Status,
                                  myuser = _db.User.FirstOrDefault(z => z.Id == x.CanidateId),
                                  mycustomresume = _db.CustomResume.FirstOrDefault(z => z.UserId == x.CanidateId),
                                  myJob = _db.Job.FirstOrDefault(z => z.Id == x.JobId),
                              }).ToList();
            return View(AppliedJob);
        }
    }
}
