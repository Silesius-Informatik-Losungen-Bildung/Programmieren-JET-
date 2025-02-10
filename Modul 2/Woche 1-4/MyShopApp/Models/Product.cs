using MyShopApp.Logic;

namespace MyShop.Models
{
    public class Product
    {
        public int ProductId { get; } = UniqueIntegerGenerator.GetNextUniqueInteger();
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required List<Supplier> Suppliers { get; set; }
    }
}
