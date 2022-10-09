using ImmigrationApp.Models;
using ImmigrationApp.Models.Google_Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Controllers
{
    [AllowAnonymous]
    public class GoogleApiController : Controller
    {
        public async Task<IActionResult> Addressautocomplete(string term)
        {
            var url = $"https://maps.googleapis.com/maps/api/place/autocomplete/json?components=country:ca&region=ca&input={term}&key=AIzaSyAwRuW4c4KIMxB9DnvLojPej1uCS6-TY40";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Accept", "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var addressAutocomplete = new AddressAutocomplete();
            if (response.IsSuccessful)
            {
                addressAutocomplete = JsonConvert.DeserializeObject<AddressAutocomplete>(response.Content);
            }
            return Json(addressAutocomplete);
        }
    }
}
