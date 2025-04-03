namespace EFCNorthwindUebungen.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public string? Description { get; set; }

        // Navigation Property zu den Produkten
        public List<Product> Products { get; set; } = new();
    }

}
