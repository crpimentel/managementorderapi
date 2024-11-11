namespace managementorderapi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        //Una orden pertenece a un cliente
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int OrderStatusId { get; set; }
        // New properties navigation
        public OrderStatu OrderStatus { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        // New properties for calculations

        // quantityProd is the total of product 
        public int QuantityProd { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Itebis { get; set; }
        public decimal Total { get; set; }

        // Relación muchos-a-muchos con Product
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
