namespace EFCNorthwindUebungen.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public decimal? UnitPrice { get; set; }
        public bool Discontinued { get; set; }

        // Navigation Property zur Kategorie
        public Category? Category { get; set; }
    }

}
