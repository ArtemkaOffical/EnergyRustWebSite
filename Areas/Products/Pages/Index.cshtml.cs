using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EnergyRust.Areas.Identity.Data;
using EnergyRust.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EnergyRust.Areas.Products.Pages
{
  
    public class IndexModel : PageModel
    {
        private readonly EnergyRustIdentityDbContext _context;
        private readonly UserManager<CustomUser> _userManager;
        private int _serverId { get; set; }
        private CustomUser _user { get; set; }
        
        public ICollection<Product> Products { get; private set; }
        public ICollection<Server> Servers { get; private set; }
        public ICollection<Category> Categories { get; private set; }
        private readonly ILogger<IndexModel> _logger;
        public string ReturnUrl { get; set; }
        public IndexModel(ILogger<IndexModel> logger,
            EnergyRustIdentityDbContext context,
            UserManager<CustomUser> userManager)
        {
            _logger = logger;
            _context = context;
           
            _serverId = _context.Servers.First().Id;
            Servers = _context.Servers.ToList();
            Categories = _context.Categories.ToList();
            _userManager = userManager;
            Products = _context.Products.Where(x => x.ServerId == _serverId).ToList();
           
        }



        public IActionResult OnGet(string returnUrl = null)
        {

            return Redirect($"~/Products/Server?id={_serverId}");
        }

        public JsonResult OnPostGetProduct(int id)
        {
            Product product = _context.Products.Find(id);
            if (product != null)
            {
                return new JsonResult(new
                {
                    state = "success",
                    pr = product
                }, new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });
            }

            return new JsonResult(new
            {
                state = "failed",
               
            });
        }

    

        public void OnGetServer(int id,int? categoryId)
        {
           
            if (categoryId == null ||categoryId == 0 )
            {
                Products = _context.Products.Where(x => x.ServerId == id).ToList();
            }
            else
            {
                Products = _context.Products.Where(x => x.CategoryId == categoryId && x.ServerId==id).ToList();
            }
        }
        
        public async Task<JsonResult> OnPostAddItem(int id,int amount,int serverId)
        {_user = await _userManager.GetUserAsync(User);
            if(_user == null) return new JsonResult(new
            {
                state = "failedAuth",
                result = "Необходимо авторизоваться в магазине!"
            });
            var shopCarts = _context.ShoppingCarts.Include(q => q.CartProducts);
            ShoppingCart products = shopCarts.First(x => x.CustomUser.Id == _user.Id && x.IdServer==serverId);
            
            var product = await _context.Products.FindAsync(id);
            var cartProduct = products.CartProducts.FirstOrDefault(x => x.Product == product);
            if (_user.Balance >= product.Price)
            {
                
                    products.CartProducts.Add(new CartProduct()
                    {
                        ProductId = id,
                        Amount = amount,
                        Product = product
                    });
                
                _user.Balance -= product.Price;
                await _context.SaveChangesAsync();
                return new JsonResult(new
                {
                    state = "success",
                    result = $"Вы купили \"{product.Name}\"",
                    displayName = $"{_user.UserName} - {_user.Balance} RUB"
                });
                
            }else
            {
                return new JsonResult(new
                {
                    state = "failed",
                    result = $"Не хватает {product.Price-_user.Balance} RUB"
                });
            }
            return new JsonResult("ok");
        }
    }
}