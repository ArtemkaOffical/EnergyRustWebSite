using System.Runtime.Serialization;

namespace EnergyRust.Models
{
    public class BabyFTGameData
    {
        
        public int Id { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }
        
        [DataMember]
        public virtual BabyFTGame BabyFTGame { get; set; }
        public int BabyFTGameId { get; set; }
    }
}