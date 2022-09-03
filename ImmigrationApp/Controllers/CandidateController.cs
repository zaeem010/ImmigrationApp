using ImmigrationApp.Currentuser;
using ImmigrationApp.Data;
using ImmigrationApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Controllers
{
    public class CandidateController : Controller
    {
        public ApplicationDbContext _db { get; set; }
        public ICurrentuser _Currentuser { get; set; }
        public CandidateController(ApplicationDbContext db, ICurrentuser Currentuser)
        {
            _Currentuser = Currentuser;
            _db = db;
        }
        [Route("/Candidate/Profile")]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var CanidateInfo = await _db.CustomResume.SingleOrDefaultAsync(x=>x.UserId == _Currentuser.GetUserId());
            var Skills = await _db.Skill.ToListAsync();
            IEnumerable<SelectListItem> Country = _db.Country.Select(c => new SelectListItem
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
    }
}
