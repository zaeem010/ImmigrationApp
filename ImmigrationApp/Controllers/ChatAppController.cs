using ImmigrationApp.Currentuser;
using ImmigrationApp.Data;
using ImmigrationApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        [Route("/ChatApp/PeopleHub/{ConnectionId}")]
        public async Task<IActionResult> CreatePeopleHub(int ConnectionId)
        {
            var peopleHub = new PeopleHub();
            peopleHub.UserId = _cur.GetUserId();
            peopleHub.ConnectedId = ConnectionId;
            await _db.PeopleHub.AddAsync(peopleHub);
            await _db.SaveChangesAsync();
            return RedirectToAction("Message");
        }
        public async Task<IActionResult> Message()
        {
            var peopleHublist = (from x in _db.PeopleHub
                                 select new PeopleHubDTO
                                 {
                                     Id = x.Id,
                                     UserId = x.UserId,
                                     ConnectedId = x.ConnectedId,
                                     ConnectedName = _db.User.Where(z => z.Id == x.ConnectedId).Select(z => z.FullName).FirstOrDefault()
                                 }).ToList();

            var chatAppHublist = new List<ChatAppHub>();
            var chatAppHub = new ChatAppHub();
            chatAppHub.PeopleHubId = 1;
            chatAppHub.UserId = _cur.GetUserId();
            chatAppHub.Type =  _db.User.Where(x => x.Id.Equals(_cur.GetUserId())).Select(x => x.Type).FirstOrDefault(); 
            var VM = new ChatHubVM 
            {
                peopleHub = peopleHublist,
                ChatAppHub = chatAppHub,
                chatAppHublist=chatAppHublist,
            };
            return View(VM);
        }
        [Route("/ChatApp/Save")]
        public async Task<IActionResult> Save(ChatAppHub ChatAppHub) 
        {
            string res = "";
            if (ChatAppHub != null)
            {
                try
                {
                    ChatAppHub.MessageDateTime = DateTime.Now;
                    await _db.ChatAppHub.AddAsync(ChatAppHub);
                    await _db.SaveChangesAsync();
                    res = "Registerd Successfully";
                    return Json(res);
                }
                catch (Exception e)
                {
                    res = e.Message;
                }
            }
            return Json(res);
        }
    }
}
