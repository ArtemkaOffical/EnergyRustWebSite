using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EnergyRust.Models
{
    [DataContract]
    public class Product
    { [DataMember]
        public int Id { get; set; }
        [DataMember]
        public  string Name { get; set; }
        [DataMember]
        public  string Description { get; set; }
        [DataMember]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [DataMember]
        public bool IsCommand { get; set; }
        [DataMember]
        public string ItemId { get; set; }
         [DataMember]
        public int Amount { get; set; }
        public string Command { get; set; }
        public string Image { get; set; }
        [DataMember]
        public virtual Category Category { get; set; }
        public int? CategoryId { get; set; }
        public virtual Server Server { get; set; }
        public int? ServerId { get; set; }
       // public  int? CustomUserId { get; set; }

    }
}