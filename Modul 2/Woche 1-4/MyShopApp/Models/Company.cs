using MyShopApp.Logic;
using MyShopApp.Models.Base;

namespace MyShop.Models
{
    public class Company: CompanyUnit
    {
        public int CompanyId {get;} = UniqueIntegerGenerator.GetNextUniqueInteger();
        public List<Product>? Products { get; set; }
        public List<Customer>? Customers { get; set; }
    }
}
