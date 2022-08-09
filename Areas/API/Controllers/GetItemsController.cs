
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
    public class GetItemsController : ControllerBase
    {
      
        private readonly EnergyRustIdentityDbContext _context;
        
        public GetItemsController(EnergyRustIdentityDbContext context)
        {
            _context = context;
        }

        
public class ProductModel
{
 
        public  string Name { get; set; }
public int Id {get;set;}
        public int Amount { get; set; }

        public bool IsCommand { get; set; }
      
        public string ItemId { get; set; }
       
        public string Image { get; set; }
        
        public string CategoryName {get;set;}
}

        [HttpGet]
        public ActionResult<List<ProductModel>> Get(string key,int? shopId,string steamId)
        {
			
            //if(key != "123") return StatusCode(302);
            var user = _context.CustomUsers.Where(x => x.SteamId == steamId).FirstAsync().Result;
            //if (user == null) return StatusCode(302);
            var cartProducts = user.ShoppingCart
                .First(x=>x.IdServer == shopId).CartProducts.ToList();
            List<ProductModel> products = new List<ProductModel>();
            foreach (var product in cartProducts)
            {
                products.Add(new ProductModel
                {
					Id = product.Id,
                Name = product.Product.Name,
                IsCommand =product.Product.IsCommand,
                Image = product.Product.Image,
                ItemId = product.Product.ItemId,
                CategoryName = product.Product.Category.Name,
                Amount = product.Amount,
                });
            }
            
           
            return products;//new JsonResult(products);
        }
    }
}
