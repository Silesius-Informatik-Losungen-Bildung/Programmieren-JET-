using MyShop.Models;

namespace MyShopApp.Logic
{
    public class CustomerLogic
    {
        private Customer _customer;
        private IEnumerable<Order>? _orders;
        private CustomerCard? _customerCard;


        public CustomerLogic(Customer customer)
        {
            _customer = customer;
        }

        public void AddOrder(Order order)
        {
            if (_orders == null)
                _orders = new List<Order>();
            _orders.ToList().Add(order);
            _customer.Orders = _orders.ToList();
            AddPoints(order);


            void AddPoints(Order order)
            {
                if (_customerCard == null)
                    return;
                _customerCard.Points = order.OrderItems.Count();
            }
        }
    }
}
