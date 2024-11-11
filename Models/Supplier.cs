using System.Text.Json.Serialization;

namespace managementorderapi.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }

        // Navigation property to related orders
        [JsonIgnore]
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
