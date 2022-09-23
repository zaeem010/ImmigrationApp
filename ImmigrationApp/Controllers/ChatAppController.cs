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
        public IActionResult Message()
        {
            var e = _db.User.Where(x => x.Id == _cur.GetUserId()).Select(x => x.Type).FirstOrDefault();
            var peopleHublist = new List<PeopleHubDTO>();
            if (e == "Employee")
            {
                peopleHublist = (from x in _db.PeopleHub
                                 select new PeopleHubDTO
                                 {
                                     Id = x.Id,
                                     UserId = x.UserId,
                                     ConnectedId = x.ConnectedId,
                                     ConnectedName = _db.User.Where(z => z.Id == x.ConnectedId).Select(z => z.FullName).FirstOrDefault()
                                 }).ToList();
            }
            else if(e == "Candidate")
            {
                peopleHublist = (from a in _db.PeopleHub
                                 select new PeopleHubDTO
                                 {
                                     Id = a.Id,
                                     UserId = a.UserId,
                                     ConnectedId = a.ConnectedId,
                                     ConnectedName = _db.User.Where(z => z.Id == a.UserId).Select(z => z.FullName).FirstOrDefault()
                                 }).ToList();
            }
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
        public IActionResult Chat(long Id)
        {
            string error;
            var chatlist = new List<ChatAppHub>();
            var chatAppHub = new ChatAppHub();
            var peopleHublist = new List<PeopleHubDTO>();
            if (Id != 0)
            {
                try
                {
                    var e = _db.User.Where(x => x.Id == _cur.GetUserId()).Select(x => x.Type).FirstOrDefault();
                    if (e == "Employee")
                    {
                        peopleHublist = (from x in _db.PeopleHub
                                         select new PeopleHubDTO
                                         {
                                             Id = x.Id,
                                             UserId = x.UserId,
                                             ConnectedId = x.ConnectedId,
                                             ConnectedName = _db.User.Where(z => z.Id == x.ConnectedId).Select(z => z.FullName).FirstOrDefault()
                                         }).ToList();
                    }
                    else if (e == "Candidate")
                    {
                        peopleHublist = (from a in _db.PeopleHub
                                         select new PeopleHubDTO
                                         {
                                             Id = a.Id,
                                             UserId = a.UserId,
                                             ConnectedId = a.ConnectedId,
                                             ConnectedName = _db.User.Where(z => z.Id == a.UserId).Select(z => z.FullName).FirstOrDefault()
                                         }).ToList();
                    }
                    chatlist = _db.ChatAppHub.Where(x => x.PeopleHubId == Id).ToList();
                    chatAppHub.PeopleHubId = Id;
                    chatAppHub.UserId = _cur.GetUserId();
                    chatAppHub.Type = _db.User.Where(x => x.Id.Equals(_cur.GetUserId())).Select(x => x.Type).FirstOrDefault();
                    error = "";
                    var VM = new ChatHubVM
                    {
                        peopleHub = peopleHublist,
                        ChatAppHub = chatAppHub,
                        chatAppHublist = chatlist,
                    };
                    return View(VM);
                }
                catch (Exception e)
                {
                    error = e.Message;
                    var VM = new ChatHubVM
                    {
                        peopleHub = peopleHublist,
                        ChatAppHub = chatAppHub,
                        chatAppHublist = chatlist,
                    };
                    return View(VM);
                }
            }
            return RedirectToAction("Message");
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
