using MyShopApp.Logic;
using MyShopApp.Models.Base;

namespace MyShop.Models
{
    public class Supplier: CompanyUnit
    {
        public int SupplierId { get; } = UniqueIntegerGenerator.GetNextUniqueInteger();
        public List<Product>? Products { get; set; }
    }
}