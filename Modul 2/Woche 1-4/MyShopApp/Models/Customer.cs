using MyShopApp.Logic;
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
    }
}
