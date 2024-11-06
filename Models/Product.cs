namespace managementorderapi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }

        // Lista de imágenes (urls por ejemplo)
        public List<string> Images { get; set; } = new List<string>();

        // Relación muchos-a-muchos con Order
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
