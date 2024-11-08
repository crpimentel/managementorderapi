namespace managementorderapi.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }   // Stores the image in binary format
        public string ImageType { get; set; }   // MIME type of the image, e.g., "image/jpeg"

        // Foreign key to the Product
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
