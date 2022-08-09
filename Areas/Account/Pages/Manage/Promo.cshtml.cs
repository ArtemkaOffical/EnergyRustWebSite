using System;
using System.Collections.Generic;
using System.Linq;
using EnergyRust.Areas.Identity.Data;
using EnergyRust.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnergyRust.Areas.Account.Pages.Manage
{
    public class PromoModel : PageModel
    {
        private readonly EnergyRustIdentityDbContext _context;
        private readonly UserManager<CustomUser> _userManager;
       
        public ICollection<Server> Servers { get; private set; }
        public void OnGet()
        {

        }

        public PromoModel(EnergyRustIdentityDbContext context,UserManager<CustomUser> userManager)
        {
            _userManager = userManager;
            _context = context;
            Servers = _context.Servers.ToList();
        }

        public IActionResult OnPost(string promoKey)
        {
           
            var user = _context.CustomUsers.Find(_userManager.GetUserId(User));
            var promoCode = _context.PromoCodes.First(x => x.Key == promoKey);
            var act = _context.PromoCodeActivations.FirstOrDefault(x=>x.PromoCodeId == promoCode.Id);
            
            
            if (act == null ) 
            {
                _context.PromoCodeActivations.Add(new PromoCodeActivation()
                {
                    CustomUserId = user.Id,
                    PromoCode = promoCode,
                    Activated = false


                });
            }
            _context.SaveChanges();
            act = _context.PromoCodeActivations.FirstOrDefault(x => x.PromoCodeId == promoCode.Id);
            if (act.Activated) return BadRequest("lol");
            //if (promoCode.Activated) return OkResult("activated");
            if (act.PromoCode.IsItem)
            {
                
                var shoppingCart = user.ShoppingCart.ToList()[new Random().Next(0, user.ShoppingCart.Count)];
                shoppingCart.CartProducts
                    .Add(new CartProduct()
                    {
                        Product = _context.Products.Find(act.PromoCode.ProductId),
                        ProductId = act.PromoCode.ProductId,
                        ShoppingCart = shoppingCart
                    });
            }
            else
            {
                user.Balance += act.PromoCode.MoneyAmount;
            }
            act.Activated = true;
            _context.SaveChanges();
            return Page();
        }
    }
}