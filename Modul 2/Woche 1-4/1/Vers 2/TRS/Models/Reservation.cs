using TRS.Logic;

namespace TRS.Models;

public class Reservation
{
    public int Id { get; } = Tools.GetNextUniqueInteger;
    public required string Name { get; init; }
    public required byte NumberOfGuests { get; set; }
    public string? AdditionalMessage { get; set; }
    public required ContactInfo ContactInfo { get; set; }
    public ReservationStatus ReservationStatus { get; set; } = ReservationStatus.Requested;
    public required TimeOnly Time { get; set; }
    public required DateOnly Date { get; set; }
    public required Restaurant Restaurant { get; set; }
    public Table Table { get; set; } = null!;
}
