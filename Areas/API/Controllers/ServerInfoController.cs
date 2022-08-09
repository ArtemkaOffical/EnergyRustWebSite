using EnergyRust.Areas.Identity.Data;
using EnergyRust.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;



namespace EnergyRust.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerInfoController : ControllerBase
    {
        private readonly EnergyRustIdentityDbContext _context;

        public ServerInfoController(EnergyRustIdentityDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult UpdateServerInfo(int serverId, int onlinePlayers, int offlinePlayers) 
        {
           Server server =  _context.Servers.Find(serverId);
            if(server==null) return new JsonResult(new { result = "response fail" });
            server.CurentPlayers = onlinePlayers;
            server.Sleepers = offlinePlayers;
            _context.Servers.Update(server);
            _context.SaveChanges();
            return new JsonResult(new { result = "server successfuly updated" });
        }
    }
}
