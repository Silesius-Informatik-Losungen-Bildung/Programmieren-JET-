namespace MyShop.Models
{
    public class Order
    {
        private static int counter = 1;
        public int OrderId { get; } = counter++;
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public List<OrderItem>? OrderItems { get; private set; }
    }
}