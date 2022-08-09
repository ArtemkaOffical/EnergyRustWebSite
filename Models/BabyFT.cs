using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EnergyRust.Models
{[DataContract]
    public class BabyFT
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string VideoUrl { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string PosterUrl { get; set; }
        [DataMember]
        public virtual List<BabyFTInteractiveData> InteractiveData { get; set; } = new List<BabyFTInteractiveData>();
       
        
    }
}