using MyShopApp.Logic;

namespace MyShop.Models
{
    public class CustomerCard
    {
        public int CustomerCardId { get; } = UniqueIntegerGenerator.GetNextUniqueInteger();
        public int Points {get; set;}
    }
}