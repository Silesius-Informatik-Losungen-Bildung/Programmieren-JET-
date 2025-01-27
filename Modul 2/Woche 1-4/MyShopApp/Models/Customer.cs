using MyShopApp;
using MyShopApp.Models.Base;

namespace MyShop.Models
{
    public class Customer: BusinessUnit
    {
        public int CustomerId { get; } = UniqueIntegerGenerator.GetNextUniqueInteger();
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public List<Order>? Orders{ get; set; }
        public CustomerCard? CustomerCard { get; set; }

        public void AddOrder(Order order)
        {
            if (Orders == null)
                Orders = new List<Order>();
            Orders.Add(order);
            AddPoints(order);
        }

        private void AddPoints(Order order)
        {
            if (CustomerCard == null)
                return;
            CustomerCard.Points = order.OrderItems.Count();
        }
    }
}
