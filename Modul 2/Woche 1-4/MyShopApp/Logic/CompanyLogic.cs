using MyShop.Models;
namespace MyShopApp.Logic
{
    public class CompanyLogic
    {
        private Company _company;
        public CompanyLogic(Company company)
        {
            _company = company;
        }

        public void AddProduct(Product product)
        {
            if (_company.Products == null)
                _company.Products = [];
            _company.Products.Add(product);
        }

        public void AddCustomer(Customer customer)
        {
            if (_company.Customers == null)
                _company.Customers = [];
            _company.Customers.Add(customer);
        }
    }
}
