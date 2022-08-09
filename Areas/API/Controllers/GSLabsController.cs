#nullable enable
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EnergyRust.Areas.Identity.Data;
using EnergyRust.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EnergyRust.Areas.API.Controllers
{  
    [ApiController]
    [Route("api/[controller]")]
    public class GSLabsController: ControllerBase
    {
      
        private readonly EnergyRustIdentityDbContext _context;
        
        public GSLabsController(EnergyRustIdentityDbContext context)
        {
            _context = context;
        }
        private class BabyFtButton
        {
            public string VideoUrl { get; set; }
            public List<BabyFTInteractiveData>? InteractiveData { get; set; }
        }
        [HttpGet]
        [Route("BabyFT")]
        public IActionResult GetBabyFtData(string? name,int? babyId)
        {
            if (babyId != null)
            {
                var data = _context.BabyFT.Find(babyId).InteractiveData;
                return new JsonResult(new {interactiveData=data});
            }

            if (name == null)
            {
                var babyFts =  _context.BabyFT.ToList();
                return new JsonResult(new {babyFts=babyFts});
            }
            var listOfBabyFts =  _context.BabyFT.Where(x => x.Name.Contains(name)).ToList();
            return new JsonResult(new {listOfBabyFts=listOfBabyFts});
        }

        [HttpGet]
        [Route("PartyTimes")]
        public IActionResult GetPartyTimesData(string? name)
        {
            if (name == null)
            {
                List<PartyTimeCategory> partyTimeCategories = _context.PartyTimeCategories.ToList();
                return new JsonResult(new {Categories = partyTimeCategories});
            }
            var listOfMusics =  _context.PartyTimes.Where(x => x.Name.Contains(name)).ToList();
            return new JsonResult(new {musics=listOfMusics});
        }
    }
}