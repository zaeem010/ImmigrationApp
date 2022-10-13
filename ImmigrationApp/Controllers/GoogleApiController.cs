using ImmigrationApp.Data;
using ImmigrationApp.Models;
using ImmigrationApp.Models.Google_Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public ApplicationDbContext _db { get; set; }
        public GoogleApiController(ApplicationDbContext db)
        {
            _db = db;
        }
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
        public async Task<IActionResult> Cityautocomplete(string term)
        {
            var Cityautocomplete = await _db.Cities.Where(x => x.city.Contains(term)).ToListAsync();
            return Json(Cityautocomplete);
        }
        public async Task<IActionResult> Provinceautocomplete(string term)
        {
            var autocomplete = await _db.States.Where(x => x.region.Contains(term)).ToListAsync();
            return Json(autocomplete);
        }  
        public async Task<IActionResult> Title_Categoryautocomplete(string term)
        {
            var autocomplete = await _db.JobSubCategory.Where(x => x.Name.Contains(term)).ToListAsync();
            return Json(autocomplete);
        }
    }
}
