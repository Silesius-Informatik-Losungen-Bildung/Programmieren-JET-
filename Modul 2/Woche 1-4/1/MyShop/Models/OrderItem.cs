namespace MyShop.Models
{
    public class OrderItem
    {
        private static int counter = 1;
        public int OrderItemId { get; } = counter++;
        public required Product Product { get; set; }
        public required int Quantity { get; set; }
    }
}