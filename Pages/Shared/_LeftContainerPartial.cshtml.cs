using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using EnergyRust.Areas.Identity.Data;
using EnergyRust.Models;
using Microsoft.AspNetCore.Authentication;
namespace EnergyRust.Pages.LeftContainer
{
    public class _LeftContainerPartialModel : PageModel
    { 
        private readonly EnergyRustIdentityDbContext _context;
        public ICollection<Server> Servers { get; private set; }
        public _LeftContainerPartialModel(EnergyRustIdentityDbContext context)
        {
            _context = context;
            Servers = _context.Servers.ToList();
        }

        public void OnGet()
        {

            //HttpClient client = clientFactory.CreateClient(name: "ApiEnergy");
            //string uri = $"WeatherForecast";
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

            //HttpResponseMessage response = await client.SendAsync(request);
            //string jsonString = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(jsonString);


        }
    }
}