using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EnergyRust.Models
{[DataContract]
    public class PartyTimeCategory
    {
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public virtual List<PartyTime> PartyTimes { get; set; } = new List<PartyTime>();
    }
}