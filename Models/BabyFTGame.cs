using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EnergyRust.Models
{
    [DataContract]
    public class BabyFTGame
    {
        public int Id { get; set; }
        
        [DataMember]
        public int AnswerId { get; set; } 
        [DataMember]
        public virtual List<BabyFTGameData> GameData { get; set; } = new List<BabyFTGameData>();
        [DataMember]
        public virtual BabyFTInteractiveData BabyFTInteractiveData { get; set; }
        public int? BabyFTInteractiveDataId { get; set; }
    }
}