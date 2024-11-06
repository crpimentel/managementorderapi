namespace managementorderapi.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Relación uno-a-muchos: un cliente puede tener varias órdenes
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
