using TRS.Logic;

namespace TRS.Models;

public class ContactInfo
{
    public int Id { get; } = Tools.GetNextUniqueInteger;
    public required string Email { get; init; }
    public required string PhoneNumber { get; init; }
    public List<Reservation>? Reservations { get; set; }
    public List<Restaurant>? Restaurants { get; set; }
}
