using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class Customer
    {
        private static int counter = 1;
        public int CustomerId { get; } = counter++;
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required string Email { get; set; }
        public required string Tel { get; set; }
        public required int Plz { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
        public List<Order>? Bestellungen { get; set; }
        public CustomerCard? KundenPass { get; set; }
    }
}
