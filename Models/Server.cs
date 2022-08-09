
using System.ComponentModel;

namespace EnergyRust.Models
{
    public class Server
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        
        public int MaxPlayers { get; set; }
      
        public int CurentPlayers { get; set; }
    
        public int Sleepers {get; set; }

    }
}