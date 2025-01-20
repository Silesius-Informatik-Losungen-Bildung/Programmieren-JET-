namespace MyShop.Models
{
    public class Supplier
    {
        private static int counter = 1;
        public int SupplierId { get; } = counter++;
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required int PostCode { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
        public string? Uid { get; set; }
        public string? Website { get; set; }
        public string? Contact { get; set; }
    }
}