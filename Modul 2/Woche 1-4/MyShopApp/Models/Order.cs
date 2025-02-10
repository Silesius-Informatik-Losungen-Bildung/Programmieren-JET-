using MyShopApp.Logic;

namespace MyShop.Models
{
    public class Order
    {
        public int OrderId { get; } = UniqueIntegerGenerator.GetNextUniqueInteger();
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public List<OrderItem>? OrderItems { get; private set; }

        public void AddOrderItem(OrderItem orderItem)
        {
            if (OrderItems == null)
                OrderItems = new List<OrderItem>();

            if (Any())
                throw new Exception(orderItem.Product.Name + " existiert bereits in dieser Bestellung!");

            //if (OrderItems.Any(bp => bp.Product.ProductId == orderItem.Product.ProductId))
            //    throw new Exception(orderItem.Product.Name + " existiert bereits in dieser Bestellung!");
            OrderItems.Add(orderItem);

            bool Any()
            {
                for (var i = 0; i < OrderItems.Count; i++)
                    if (OrderItems[i].Product.ProductId == orderItem.Product.ProductId)
                            return true;
                return false;
            }
        }
    }
}