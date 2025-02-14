using MyShop.Models;

namespace MyShopApp.Logic
{
    public class CustomerCardLogic
    {
        private CustomerCard _customerCard;
        public CustomerCardLogic(CustomerCard customerCard)
        {
            _customerCard = customerCard;
        }

        public void AddPoints(int points)
        {
            if (_customerCard == null)
                _customerCard = new CustomerCard();
            _customerCard.Points = points;
        }

    }
}
