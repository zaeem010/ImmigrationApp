using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using ImmigrationApp.Models;
using Microsoft.AspNetCore.Http;
using ImmigrationApp.Data;

namespace ImmigrationApp.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Add the Notification/Message to the returning view
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="result">Bolean, either success or error</param>
        /// <param name="delay">in miliseconds, how much longer the notification will show. Default 3.5 sec</param>
        public void AddNotificationToView(string message, bool result, int delay = 3500)
        {
            var ToasterResult = new ToasterResult()
            {
                Success = result,
                Message = message,
                Delay = delay
            };

            TempData["ToasterResult"] = JsonSerializer.Serialize(ToasterResult);
        }
        
    }
}
