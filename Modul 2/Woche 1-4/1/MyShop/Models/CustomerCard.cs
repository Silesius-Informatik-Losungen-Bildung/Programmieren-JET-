namespace MyShop.Models
{
    public class CustomerCard
    {
        private static int counter = 1;
        public int CustomerCardId { get; } = counter++;
        public int Points {get; set;}
    }
}