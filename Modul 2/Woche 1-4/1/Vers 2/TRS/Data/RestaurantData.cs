using TRS.Models;

namespace TRS.Data
{
    public static class RestaurantData
    {
        static RestaurantData()
        {
            Restaurants = new List<Restaurant>();
        }
        public static List<Restaurant>? Restaurants { get; set; }
    }
}
