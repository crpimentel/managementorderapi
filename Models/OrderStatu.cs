using System.Text.Json.Serialization;

namespace managementorderapi.Models
{
    public class OrderStatu
    {
        public int Id { get; set; }
        public string StatusName { get; set; }

        // Navigation property to related orders
        [JsonIgnore]
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
