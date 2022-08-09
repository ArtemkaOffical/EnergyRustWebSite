using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace EnergyRust.Models
{
	[DataContract]
    public class CartProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
		[DataMember]
        public virtual Product Product { get; set; }
		[DataMember]
        public int Amount { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}