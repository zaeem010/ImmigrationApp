using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Repositries
{
    public interface ICommonRepo
    {
        IEnumerable<SelectListItem> GetCountryList(string selected);
    }
}
