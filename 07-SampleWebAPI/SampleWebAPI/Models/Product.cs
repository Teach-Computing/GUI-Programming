namespace SampleWebAPI.Models
{
    public class Product
    {
        public int Id { get; set; } // Primary key
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}
