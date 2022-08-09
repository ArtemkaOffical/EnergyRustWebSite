using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EnergyRust.Models
{[DataContract]
    public class PartyTime
    {
        public int Id { get; set; }
        [DataMember]
       public string VideoUrl { get; set; }
       [DataMember]
       public string Name { get; set; }
       [DataMember]
       public string PosterUrl { get; set; }
      
       public int NumberOfLaunches { get; set; }
        public virtual PartyTimeCategory Category { get; set; }
        public int CategoryId { get; set; }
    }
}