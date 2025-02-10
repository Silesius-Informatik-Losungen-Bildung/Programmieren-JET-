using MyShop.Models;
namespace MyShopApp.Logic
{
    public class CompanyLogic
    {
        private Company _company;
        private IEnumerable<Product>? _products;
        private IEnumerable<Customer>? _customers;

        public CompanyLogic(Company company)
        {
            _company = company;
        }

        public void AddProduct(Product product)
        {
            if (_products == null)
                _products = [];
            _products.ToList().Add(product);
        }

        public void AddCustomer(Customer customer)
        {
            if (_customers == null)
                _customers = [];
            _customers.ToList().Add(customer);
            _company.Customers = _customers.ToList();
        }
    }
}
