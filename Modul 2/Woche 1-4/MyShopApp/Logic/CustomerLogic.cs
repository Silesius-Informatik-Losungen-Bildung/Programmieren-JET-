using MyShop.Models;

namespace MyShopApp.Logic
{
    public class CustomerLogic
    {
        private Customer _customer;
        public CustomerLogic(Customer customer)
        {
            _customer = customer;
        }

        public void AddOrder(Order order)
        {
            if (_customer.Orders == null)
                _customer.Orders = [];
            _customer.Orders.Add(order);
        }
    }
}
