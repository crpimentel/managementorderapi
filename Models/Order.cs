namespace managementorderapi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        //Una orden pertenece a un cliente
        public int ClientId { get; set; }
        public Client Client { get; set; }

        // Relación muchos-a-muchos con Product
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
