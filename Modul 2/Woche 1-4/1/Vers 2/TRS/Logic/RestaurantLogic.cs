using TRS.Data;
using TRS.Models;

namespace TRS.Logic
{
    public class RestaurantLogic : IRestaurantLogic
    {
        public void Register(Restaurant restaurnat)
        {
             
            // TODO 
            //Validierung der Daten

            RestaurantData.Restaurants.Add(restaurnat);
        }
    }
}
