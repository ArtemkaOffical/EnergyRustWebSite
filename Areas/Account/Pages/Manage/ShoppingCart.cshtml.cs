using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnergyRust.Areas.Identity.Data;
using EnergyRust.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EnergyRust.Areas.Account.Pages.Manage
{
    public partial class ShoppingCartModel : PageModel
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly EnergyRustIdentityDbContext _context;
        public ICollection<Server> Servers { get; private set; }
         public  ShoppingCart ShoppingCart { get; set; }
         public IList<Product> Productss { get; set; }
         public IList<CartProduct> Products { get; set; }
        
            public ShoppingCartModel(
            UserManager<CustomUser> userManager,
            EnergyRustIdentityDbContext context)
        {
            _userManager = userManager;
            _context = context;
            Servers = _context.Servers.ToList();
        }

        private async Task LoadAsync(CustomUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            Productss = new List<Product>();
            foreach (var q in _context.CustomUsers
                         .Include(sh => sh.ShoppingCart)
                         .FirstOrDefaultAsync(curUser=>curUser.Id == user.Id)
                         .Result.ShoppingCart)
            {
                foreach (var t in q.CartProducts)
                {
                    if (_context.Products.Find(t.ProductId) != null)
                    {
                        Productss.Add(_context.Products.Find(t.ProductId));
                        Products = _context.CartProducts.ToList();
                    }
                }
            }

           

        }
        public async Task<IActionResult> OnGetAsync()
        {
           
            await LoadAsync(await _userManager.GetUserAsync(User));
            return Page();
        }
    }
}