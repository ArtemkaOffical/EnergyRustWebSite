using EnergyRust.Areas.Identity.Data;
using EnergyRust.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EnergyRust.Areas.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MoneyController : ControllerBase
    {
        private readonly EnergyRustIdentityDbContext _context;
        
        public MoneyController(EnergyRustIdentityDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string key,string type,decimal amount, string steamId)
        {
            if(key != "123") return NotFound();
            var user = _context.CustomUsers.Where(x => x.SteamId == steamId).FirstAsync().Result;
            if (user == null) return NotFound();
            if(amount==0) return NotFound();
            switch (type)
            {
                case "plus":
                {
                    user.Balance += amount;
                    break;
                }
                case "minus":
                {
                    if (user.Balance >= amount)
                    {
                        user.Balance -= amount;
                    }
                    break;
                }
                default:
                {
                    return NotFound("type error");
                }
            }

           await _context.SaveChangesAsync();
            return Ok($"Balance for player was changed");
        }
    }
}