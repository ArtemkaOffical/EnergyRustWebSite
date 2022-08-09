using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EnergyRust.Areas.Identity.Data;
using EnergyRust.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnergyRust.Areas.Account.Pages.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly EnergyRustIdentityDbContext _context;
        public ICollection<Server> Servers { get; private set; }
        public IndexModel(
            UserManager<CustomUser> userManager,EnergyRustIdentityDbContext context,
            SignInManager<CustomUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            Servers = _context.Servers.ToList();
        }
        
        public async Task<IActionResult> OnGetAsync()
        {
            
            return Page();
        }

       
    }
}
