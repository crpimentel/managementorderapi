using System.Text.Json.Serialization;

namespace managementorderapi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }  // New property for discount

        // Navigation property for related images
        public ICollection<ProductImage> ProductImages { get; set; }
        // Relación muchos-a-muchos con Order
        [JsonIgnore]
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
