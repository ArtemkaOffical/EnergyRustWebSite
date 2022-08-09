using System.Runtime.Serialization;

namespace EnergyRust.Models
{
    [DataContract]
    public class BabyFTInteractiveData
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }
        [DataMember]
        public string AudioUrl { get; set; }
        [DataMember]
        public virtual BabyFT BabyFT { get; set; }
        public int BabyFTId { get; set; }
        
        
        [DataMember]
        public virtual BabyFTGame BabyFTGame { get; set; }
       
        
        
        
        
    }
}