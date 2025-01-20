namespace MyShop.Models
{
    public class Product
    {
        private static int counter = 1;
        public int ProductId { get; } = counter++;
        public required string Name { get; set; }

        public required decimal Price { get; set; }

        public required List<Supplier> Suppliers { get; set; }
    }
}
