using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using EnergyRust.Areas.Identity.Data;
using EnergyRust.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnergyRust.Areas.Admin.Pages
{
    [Authorize(Roles ="Admin")]
    public class IndexModel : PageModel
    {
        private readonly EnergyRustIdentityDbContext _context;
        public readonly List<ItemDefinitions> ItemDefinitions;  public ICollection<Server> Servers { get; private set; }
        [BindProperty]
        public Product Product { get; set; }
        public IndexModel(EnergyRustIdentityDbContext context)
        {
            
            _context = context;
            Servers = _context.Servers.ToList();
            ItemDefinitions = _context.ItemDefinitions.ToList();
           
           
        }
        public void OnGet()
        {
            
        }

        public JsonResult OnPostGetItem(int id)
        {
            ItemDefinitions itemDefinition = _context.ItemDefinitions.Find(id);
            if (itemDefinition != null)
            {
                return new JsonResult(new
                {
                    state = "success",
                    item = itemDefinition
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

        public JsonResult OnPost()
        {
            try
            {
                _context.Products.Add(Product);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return new JsonResult(new
                {
                    state = "failed",
                    result = e.Message,
               
                });
            }
            return new JsonResult(new
            {
                state = "success",
                result = "Товар добавлен в базу",
               
            });
        }
    }
}