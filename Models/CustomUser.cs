
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;

namespace EnergyRust.Models
{
   
    public class CustomUser : IdentityUser
    {
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; set; } = 0;
        public string SteamId { get; set; }
        
        public int ShoppingCartId { get; set; }
        public string SteamAvatar { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }

        public CustomUser() {
            ShoppingCart = new List<ShoppingCart>();
        }
    }
}