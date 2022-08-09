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
namespace EnergyRust.Pages
{
    public class IndexModel : PageModel
    {   private readonly IHttpClientFactory clientFactory;
        private readonly ILogger<IndexModel> _logger;
        private readonly EnergyRustIdentityDbContext _context; public string ReturnUrl { get; set; }
        public ICollection<Server> Servers { get; private set; }
        public IndexModel(ILogger<IndexModel> logger,EnergyRustIdentityDbContext context,IHttpClientFactory d)
        {clientFactory = d; _context = context;
            _logger = logger;Servers = _context.Servers.ToList();
        }

        public void OnGet(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ReturnUrl = returnUrl;
            //HttpClient client = clientFactory.CreateClient(name: "ApiEnergy");
            //string uri = $"WeatherForecast";
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

            //HttpResponseMessage response = await client.SendAsync(request);
            //string jsonString = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(jsonString);


        }
    }
}
