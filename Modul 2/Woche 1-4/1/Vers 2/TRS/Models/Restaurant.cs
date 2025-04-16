using TRS.Logic;

namespace TRS.Models;

public class Restaurant
{
    public int Id { get; } = Tools.GetNextUniqueInteger;
    public required string Name { get; set; }
    public required string PostalCode { get; set; }
    public required string City { get; set; }
    public required string StreetHouseNr { get; set; }
    public required string Country { get; set; }
    public bool Activ { get; set; } = true;
    public required ContactInfo ContactInfo { get; set; }
    public List<Reservation>? Reservations { get; set; }
    public List<Table>? Tables { get; set; }
}
