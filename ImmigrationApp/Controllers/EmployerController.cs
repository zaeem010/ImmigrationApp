﻿using ImmigrationApp.Currentuser;
using ImmigrationApp.Data;
using ImmigrationApp.Models;
using ImmigrationApp.Services;
using ImmigrationApp.Services.CommonRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Controllers
{
    public class EmployerController : BaseController
    {
        public ApplicationDbContext _db { get; set; }
        public ICompanyInfoRepo _companyInfo { get; set; }
        public ICommonRepo _CommonRepo { get; set; }
        public ICurrentuser _Currentuser { get; set; }
        private readonly IWebHostEnvironment host;
        public EmployerController(ApplicationDbContext db, ICommonRepo CommonRepo, ICurrentuser Currentuser, ICompanyInfoRepo companyInfo, IWebHostEnvironment host)
        {
            _db = db;
            _companyInfo = companyInfo;
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
            var VM = new CompanyInfoVM
            {
                CompanyInfo=CompanyInfo,
                CountryList=Country,
            };
            return View(VM);
        }
        [AllowAnonymous]
        [Route("/Company/Profile-View/{Slugname}")]
        [HttpGet]
        public async Task<IActionResult> ViewProfile(string Slugname)
        {
            var CompanyInfo = await _companyInfo.GetCompanyInfoByslugName(Slugname);
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
        //Post A Job//
        public async Task<IActionResult> JobPost()
        {

            return View();
        }
    }
}