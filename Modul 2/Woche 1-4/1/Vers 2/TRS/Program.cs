using TRS.Logic;
using TRS.Models;

namespace TRS
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var restaurantLogic = new RestaurantLogic();
            var restaurant = new Restaurant()
            {
                Name = "Musil",
                ContactInfo = new ContactInfo
                {
                    Email = "musil@musil.at",
                    PhoneNumber = "1234567890"
                },
                PostalCode = "1140",
                City = "Wien",
                StreetHouseNr = "Braillestr. 12",
                Country = Country.AT
            };

            //.....

            restaurantLogic.Register(restaurant);





            //    // Grundstammdaten
            //    var restaurant = new Restaurant()
            //    {
            //        Name = "Musil",
            //        ContactInfo = new ContactInfo
            //        {
            //            Email = "musil@musil.at",
            //            PhoneNumber = "1234567890"
            //        },
            //        PostalCode = "1140",
            //        City = "Wien",
            //        StreetHouseNr = "Braillestr. 12",
            //        Country = Country.AT
            //    };

            //    // Stammdaten Sesseln
            //    restaurant.Tables = new List<Table>()
            //    {
            //        new Table
            //            {
            //            TableNumber = "TI5656",
            //            NumberOfSeats = 5,
            //            Restaurant = restaurant
            //            },
            //        new Table
            //            {
            //            TableNumber = "TAX7878",
            //            NumberOfSeats = 6,
            //            Restaurant = restaurant
            //            }
            //    };

            //    // Bewegungsdaten (Resevierungen)

            //    restaurant.Reservations = new List<Reservation>();

            //    var reservation1 = new Reservation
            //    {
            //        Name = "Tobias",
            //        ContactInfo = new ContactInfo
            //        {
            //            Email = "tobias@tobias.at",
            //            PhoneNumber = "956565656"
            //        },
            //        NumberOfGuests = 5,
            //        Restaurant = restaurant,
            //        Date = new DateOnly(2025, 04, 27),
            //        Time = ReservationTime.T2130,
            //        AdditionalMessage = "Hallo, wir kommen..."
            //    };

            //    restaurant.Reservations.Add(reservation1);

            //    // Restaurant-Mitarbeiter ordnet einer Resevierung einen Tisch zu
            //    restaurant.Reservations[0].Table = restaurant.Tables[0];

            //    // Restaurant-Mitarbeiter sezt den Status der Reservierung auf "reserverd"
            //    restaurant.Reservations[0].ReservationStatus = ReservationStatus.Reserved;
            //}
        }
    }

}
