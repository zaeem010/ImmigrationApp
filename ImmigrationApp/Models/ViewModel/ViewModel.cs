using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Models
{
    public class CompanyInfoVM
    {
        public CompanyInfo CompanyInfo { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }
    }
    public class HomeVM
    {
        public List<CompanyInfo> CompanyInfoList { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }
    }
}
