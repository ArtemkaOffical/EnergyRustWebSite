using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyRust.Models
{
    public class PromoCode
    {
        public int Id { get; set; }
        public string Key { get; set; }
      
        public bool IsItem { get; set; }
        public int ProductId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public  decimal MoneyAmount { get; set; }
        
        //public DateTime DateTime { get; set; }
    }
}