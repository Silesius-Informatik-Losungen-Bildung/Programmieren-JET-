using MyShopApp.Logic;

namespace MyShop.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; } = UniqueIntegerGenerator.GetNextUniqueInteger();
        public required Product Product { get; set; }
        public required int Quantity { get; set; }
    }
}