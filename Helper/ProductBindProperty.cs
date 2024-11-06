using Microsoft.AspNetCore.Mvc;

namespace managementorderapi.Helper
{
    [BindProperties]
    public class ProductBindProperty
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public int? stock { get; set; }
        public string? description { get; set; }
        public decimal? price { get; set; }
    }
}
