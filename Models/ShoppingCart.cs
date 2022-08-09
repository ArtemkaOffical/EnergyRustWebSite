using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EnergyRust.Models
{ [DataContract]
    public class ShoppingCart
    {
        public int Id { get; set; }
        public virtual CustomUser CustomUser { get; set; }
        public string CustomUserId{ get; set; }
        
        public virtual int IdServer { get; set; }
        
        [DataMember]
        public virtual ICollection<CartProduct> CartProducts { get; set; }

        public ShoppingCart() {
            CartProducts = new List<CartProduct>();
        }
    }
}