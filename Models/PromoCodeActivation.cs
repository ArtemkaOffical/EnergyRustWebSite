using System;
using System.Collections;
using System.Collections.Generic;

namespace EnergyRust.Models
{
    public class PromoCodeActivation
    {
        public int Id { get; set; }
        
        public string CustomUserId { get; set; }
        public bool Activated { get; set; }
        public virtual PromoCode PromoCode { get; set; }
        public int? PromoCodeId { get; set; }
        
    }
}