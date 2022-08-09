
using EnergyRust.Areas.Identity.Data;
using EnergyRust.Models;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace EnergyRust.Areas.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RemoveItemController : ControllerBase
    {

        private readonly EnergyRustIdentityDbContext _context;

        public RemoveItemController(EnergyRustIdentityDbContext context)
        {
            _context = context;
        }




        [HttpPost]
        public IActionResult RemoveItemFromCart(int? shopId, string steamId,int productId)
        {

            var user = _context.CustomUsers.Where(x => x.SteamId == steamId).FirstAsync().Result;
           
            var cartProducts = user.ShoppingCart
                .First(x => x.IdServer == shopId).CartProducts.ToList();
            var product = cartProducts.FirstOrDefault(x => x.Id == productId);
            if (product != null)
            {

                _context.CartProducts.Remove(product);
                _context.SaveChanges();
                return new JsonResult(new { result = "success full"});
            }

            return new JsonResult(new { result = "response fail"});
        }
    }
}

