namespace managementorderapi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }

        // Navigation property for related images
        public ICollection<ProductImage> ProductImages { get; set; }
        // Relación muchos-a-muchos con Order
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
