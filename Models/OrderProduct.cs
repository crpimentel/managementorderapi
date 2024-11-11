using System.Text.Json.Serialization;

namespace managementorderapi.Models
{
    public class OrderProduct
    {
        [JsonIgnore]
        public int OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int QuantityProd { get; set; }
        public decimal DiscountProd { get; set; }
    }
}
