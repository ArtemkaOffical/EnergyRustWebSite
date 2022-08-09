using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using EnergyRust.Areas.Identity.Data;
using EnergyRust.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace EnergyRust.Areas.Account.Pages
{
    [AllowAnonymous]
    public class ExternalLoginModel : PageModel
    {
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly UserManager<CustomUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly EnergyRustIdentityDbContext _context;
        private readonly ILogger<ExternalLoginModel> _logger;
        public ICollection<Server> Servers { get; private set; }
        public ExternalLoginModel(
            SignInManager<CustomUser> signInManager,
            EnergyRustIdentityDbContext context,
            UserManager<CustomUser> userManager,
            ILogger<ExternalLoginModel> logger,
            IEmailSender emailSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _context = context;
         
            Servers = _context.Servers.ToList();
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ProviderDisplayName { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public IActionResult OnGetAsync()
        {
            return RedirectToPage("./Login");
        }

        public IActionResult OnPost(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Page("./ExternalLogin", pageHandler: "Callback", values: new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> OnGetCallbackAsync(string returnUrl = null, string remoteError = null)
        {
            try
            {
                returnUrl = returnUrl ?? Url.Content("~/");
                
                if (remoteError != null)
                {
                    ErrorMessage = $"Error from external provider: {remoteError}";
                    return RedirectToPage("./Login", new {ReturnUrl = returnUrl});
                }

                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    ErrorMessage = "Error loading external login information.";
                    return RedirectToPage("./Login", new {ReturnUrl = returnUrl});
                }
                
                // Sign in the user with this external login provider if the user already has a login.
                var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,
                    isPersistent: false, bypassTwoFactor: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation("{Name} logged in with {LoginProvider} provider.",
                        info.Principal.Identity.Name, info.LoginProvider);
                    return LocalRedirect(returnUrl);
                }

                if (result.IsLockedOut)
                {
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ProviderDisplayName = info.ProviderDisplayName;

                    if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
                    {
                        Input = new InputModel
                        {
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                        };
                    }
                     Challenge(new AuthenticationProperties {RedirectUri = returnUrl}, "Steam");
                   
                  //  ReturnUrl = returnUrl;
                  

                    return Page();
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

      
        public async Task<IActionResult> OnPostConfirmationAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information during confirmation.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            if (ModelState.IsValid)
            {
                var shoppingCart = new List<ShoppingCart>();
                foreach (var server in _context.Servers)
                {
                    shoppingCart.Add(new ShoppingCart()
                    {
                       
                        IdServer = server.Id,
                        CartProducts = new List<CartProduct>()
                    });
                }

                HttpClient client = new HttpClient();
                var steamID = info.Principal.FindFirstValue(ClaimTypes.NameIdentifier).Split('/').Last();
                var GetSteamData = client.GetAsync(
                    "http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=9F0028A663DCFC211E920616E5CE5659&steamids="+steamID);
            
                var user = new CustomUser {SteamId = steamID,ShoppingCart = shoppingCart,
                    SteamAvatar = JObject.Parse(GetSteamData.Result.Content.ReadAsStringAsync().Result)["response"]["players"][0]["avatarfull"].ToString(),
                    UserName = JObject.Parse(GetSteamData.Result.Content.ReadAsStringAsync().Result)["response"]["players"][0]["personaname"].ToString(), 
                    Email = Input.Email, EmailConfirmed=true };

                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);
                    await _signInManager.SignInAsync(user, isPersistent: false, info.LoginProvider);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);
                        return Redirect("~/Products");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            ProviderDisplayName = info.ProviderDisplayName;
            ReturnUrl = returnUrl;
            return Page();
        }
    }
}
