using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EnergyRust.Areas.Identity.Data;
using EnergyRust.Models;

namespace EnergyRust.Areas.Account.Pages.Manage
{
    public class BalanceModel : PageModel
    {
        public ICollection<Server> Servers { get; private set; }
        private readonly EnergyRustIdentityDbContext _context;
        public BalanceModel(EnergyRustIdentityDbContext context)
        {
            _context = context;

            Servers = _context.Servers.ToList();
        }
    }
}
