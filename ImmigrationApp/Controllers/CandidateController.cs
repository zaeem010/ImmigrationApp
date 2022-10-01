using ImmigrationApp.Currentuser;
using ImmigrationApp.Data;
using ImmigrationApp.Models;
using LinqKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Controllers
{
    public class CandidateController : Controller
    {
        public ApplicationDbContext _db { get; set; }
        public ICurrentuser _Currentuser { get; set; }
        private readonly IWebHostEnvironment host;
        public CandidateController(ApplicationDbContext db, ICurrentuser Currentuser, IWebHostEnvironment host)
        {
            _Currentuser = Currentuser;
            _db = db;
            this.host = host;
        }
        [Route("/Candidate/Profile")]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var CanidateInfo = await _db.CustomResume
                .Include(x=>x.ResumeEducationList)
                .Include(x=>x.ResumeExperienceList)
                .Include(x=>x.ResumeSkillChildList)
                .Include(x=>x.ResumeLanguageChildList)
                .Include(x=>x.ResumeLinkChildList)
                .SingleOrDefaultAsync(x=>x.UserId == _Currentuser.GetUserId());
            var Skills = await _db.Skill.ToListAsync();
            IEnumerable<SelectListItem> Country = _db.Country.OrderBy(x=>x.CountryName).Select(c => new SelectListItem
            {
                Value = c.CountryName,
                Text = c.CountryName,
                Selected = CanidateInfo.Country == c.CountryName
            });
            var VM = new CanidateVM
            {
                CustomResume = CanidateInfo,
                CountryList = Country,
                SkillList = Skills,
            };
            return View(VM);
        }
        [AllowAnonymous]
        [Route("/Candidate/Profile-View/{Slugname}")]
        [HttpGet]
        public async Task<IActionResult> ProfileView(string Slugname)
        {
            var CanidateInfo = await _db.CustomResume
                .Include(x=>x.ResumeEducationList)
                .Include(x=>x.ResumeExperienceList)
                .Include(x=>x.ResumeSkillChildList)
                .Include(x=>x.ResumeLanguageChildList)
                .Include(x=>x.ResumeLinkChildList)
                .SingleOrDefaultAsync(x=>x.SlugName == Slugname);
            var VM = new CanidateVM
            {
                CustomResume = CanidateInfo,
            };
            return View(VM);
        }
        [AllowAnonymous]
        [Route("/Candidate/Browse-Candidate")]
        [HttpGet]
        public async Task<IActionResult> BrowseCandidate()
        {
            var CanidateInfo = await _db.CustomResume
                .Include(x=>x.ResumeEducationList)
                .Include(x=>x.ResumeExperienceList)
                .Include(x=>x.ResumeSkillChildList)
                .Include(x=>x.ResumeLanguageChildList)
                .Include(x=>x.ResumeLinkChildList)
                .Include(x=>x.User)
                .ToListAsync();
            var VM = new CanidateVM
            {
                CustomResumeList = CanidateInfo,
            };
            return View(VM);
        }
        [AllowAnonymous]
        [Obsolete]
        public async Task<JsonResult> searchcanidate(SearchcanidateDTO SearchcanidateDTO)
        {
            var predicate = PredicateBuilder.True<CustomResume>();

            if (!string.IsNullOrEmpty(SearchcanidateDTO.keyword))
            {
                predicate = predicate.Or(c => c.FirstName.Contains(SearchcanidateDTO.keyword));
            }
            if (!string.IsNullOrEmpty(SearchcanidateDTO.keyword))
            {
                predicate = predicate.Or(c => c.LastName.Contains(SearchcanidateDTO.keyword));
            }
            if (!string.IsNullOrEmpty(SearchcanidateDTO.keyword))
            {
                predicate = predicate.Or(c => c.Headline.Contains(SearchcanidateDTO.keyword));
            }
            if (!string.IsNullOrEmpty(SearchcanidateDTO.address))
            {
                predicate = predicate.And(c => c.Street.Contains(SearchcanidateDTO.address));
            }
            //
            var canidateInfo = await _db.CustomResume.Where(predicate)
                .Include(x => x.ResumeEducationList)
                .Include(x => x.ResumeExperienceList)
                .Include(x => x.ResumeSkillChildList)
                .Include(x => x.ResumeLanguageChildList)
                .Include(x => x.ResumeLinkChildList)
                .ToListAsync();
            return Json(canidateInfo);
        }
        [HttpPost]
        public async Task<JsonResult> Update(IFormCollection form)
        {
            var Request = form["candidaterequest"];
            var CustomResume = JsonConvert.DeserializeObject<CustomResume>(Request);
            //
            Random r = new Random();
            int num = r.Next();
            var webrootpath = host.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            string Username = await _db.User.Where(x=>x.Id.Equals(_Currentuser.GetUserId())).Select(x => x.FirstName).FirstOrDefaultAsync();
            //Image Insert
            if (files.Count > 0)
            {
                var uploads = Path.Combine(webrootpath, "Upload");
                var Ext = Path.GetExtension(files[0].FileName);
                using (var stream = new FileStream(Path.Combine(uploads, $"{Username}_{num}_{Ext}"), FileMode.Create))
                {
                    files[0].CopyTo(stream);
                }
                CustomResume.ResumeUrlPath = $"{Username}_{num}_{Ext}";
            }
            var Sk = await _db.ResumeSkillChild.Where(x => x.CustomResumeId == CustomResume.Id).ToListAsync();
            var skill = await _db.Skill.Select(x=>x.NormalizedName).ToListAsync();
            foreach (var item in Sk)
            {
                var ch = skill.Any(c => c == item.SkillName.ToUpper());
                if (!ch)
                {
                    var addskill = new Skill();
                    addskill.Name = item.SkillName;
                    addskill.NormalizedName = item.SkillName.ToUpper();
                    await _db.Skill.AddAsync(addskill);
                }
            }
            _db.ResumeExperience.RemoveRange(await _db.ResumeExperience.Where(x => x.CustomResumeId == CustomResume.Id).ToListAsync());
            _db.ResumeEducation.RemoveRange(await _db.ResumeEducation.Where(x => x.CustomResumeId == CustomResume.Id).ToListAsync());
            _db.ResumeSkillChild.RemoveRange(Sk);
            _db.ResumeLanguageChild.RemoveRange(await _db.ResumeLanguageChild.Where(x => x.CustomResumeId == CustomResume.Id).ToListAsync());
            _db.ResumeLinkChild.RemoveRange(await _db.ResumeLinkChild.Where(x => x.CustomResumeId == CustomResume.Id).ToListAsync());
            //
            string slugname = CustomResume.FirstName + ' ' + CustomResume.LastName;
            CustomResume.SlugName = slugname.Replace(" ", "-");
            _db.CustomResume.Update(CustomResume);
            await _db.SaveChangesAsync();
            return Json("Updated Successfully");
        }
        [HttpGet]
        [Route("/Candidate/GetSkill")]
        public async Task<JsonResult> GetSkill(string term)
        {
            term = term.ToUpper();
            var Skills = await _db.Skill.Where(c=>c.NormalizedName.Contains(term)).Distinct().ToListAsync();
            return Json(Skills);
        }
    }
}
