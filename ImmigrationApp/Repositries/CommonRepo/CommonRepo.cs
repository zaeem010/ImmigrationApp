using ImmigrationApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Repositries
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
            IEnumerable<SelectListItem> Country = _db.Country.OrderBy(x => x.CountryName).Select(c => new SelectListItem
            {
                Value = c.CountryName,
                Text = c.CountryName,
                Selected = selected == c.CountryName
            });
            return Country;
        }
    }
}
