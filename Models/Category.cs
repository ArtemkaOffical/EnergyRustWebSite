namespace EnergyRust.Models
{
    public class Category
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public virtual Product Product { get; set; }
    }
}