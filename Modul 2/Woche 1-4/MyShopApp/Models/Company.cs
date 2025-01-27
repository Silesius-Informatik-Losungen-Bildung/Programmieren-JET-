using MyShopApp;
using MyShopApp.Models.Base;

namespace MyShop.Models
{
    public class Company: CompanyUnit
    {
        public int CompanyId {get;} = UniqueIntegerGenerator.GetNextUniqueInteger();
        public List<Product>? Products { get; set; }
        public List<Customer>? Customers { get; set; }

        public void AddProduct(Product product)
        {
            if (Products == null)
                Products = new List<Product>();
            Products.Add(product);
        }

        public void AddCustomer(Customer customer)
        {
            if (Customers == null)
                Customers = new List<Customer>();
            Customers.Add(customer);
        }
    }
}
