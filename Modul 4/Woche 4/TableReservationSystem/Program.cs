using TableReservationSystem.Data;
using TableReservationSystem.Models;

namespace TableReservationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using var trsContext = new TableReservationSystemContext();

            // Grundstammdaten
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
                CountryCode = "AT",
                Activ = true
            };


            // Stammdaten Sesseln
            var table1 = new Table
            {
                TableNumber =  Guid.NewGuid().ToString().Substring(0,10),
                NumberOfSeats = 5,
                Activ = true
            };
            var table2 = new Table
            {
                TableNumber = Guid.NewGuid().ToString().Substring(0, 10),
                NumberOfSeats = 6,
                Activ = true
            };        
            restaurant.Tables.Add(table1);
            restaurant.Tables.Add(table1);



            // Bewegungsdaten (Resevierungen)
            var reservation1 = new Reservation
            {
                Name = "Tobias",
                ContactInfo = new ContactInfo
                {
                    Email = "tobias@tobias.at",
                    PhoneNumber = "956565656"
                },
                NumberOfGuests = 5,
                Date = new DateOnly(2025, 04, 27),
                ReservationTimeId = 1,
                AdditionalMessage = "Hallo, wir kommen...",
            };

            restaurant.Reservations.Add(reservation1);

            
            
            
            trsContext.Restaurant.Add(restaurant);
            trsContext.SaveChanges();


            // Restaurant-Mitarbeiter ordnet einer Resevierung einen Tisch zu
            restaurant.Reservations.First().Table = restaurant.Tables.First();

            // Restaurant-Mitarbeiter sezt den Status der Reservierung auf "reserverd"
            restaurant.Reservations.First().ReservationStatus
                = trsContext.ReservationStatus.FirstOrDefault(rs => rs.Caption == "Reserverd");

            trsContext.SaveChanges();

        }
    }
}
