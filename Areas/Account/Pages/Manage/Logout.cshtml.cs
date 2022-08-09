using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnergyRust.Areas.Identity.Data;
using EnergyRust.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EnergyRust.Areas.Account.Pages
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly EnergyRustIdentityDbContext _context;
        public string ReturnUrl { get; set; }
        public ICollection<Server> Servers { get; private set; }
        public LogoutModel(SignInManager<CustomUser> signInManager,EnergyRustIdentityDbContext context, ILogger<LogoutModel> logger)
        {
            _context = context;
            _signInManager = signInManager;
            _logger = logger;
            Servers = _context.Servers.ToList();
        }

        public void OnGet(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
