using ImmigrationApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Services.CommonRepo
{
    public class CommonRepo : ICommonRepo
    {
        public ApplicationDbContext _db { get; set; }
        public CommonRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetCountryList(string selected)
        {
            IEnumerable<SelectListItem> Country = _db.Country.Select(c => new SelectListItem
            {
                Value = c.CountryName,
                Text = c.CountryName,
                Selected = selected == c.CountryName
            });
            return Country;
        }
    }
}
