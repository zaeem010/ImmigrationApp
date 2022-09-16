using ImmigrationApp.Currentuser;
using ImmigrationApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Controllers
{
    public class ChatAppController : Controller
    {
        private ApplicationDbContext _db { get; set; }
        private ICurrentuser _cur { get; set; }
        public ChatAppController(ICurrentuser Cur, ApplicationDbContext db)
        {
            _db = db;
            _cur = Cur;
        }
        public IActionResult Message()
        {
            return View();
        }
    }
}
