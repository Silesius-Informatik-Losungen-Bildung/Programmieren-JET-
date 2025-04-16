using TRS.Logic;

namespace TRS.Models;

public  class Table
{
    public int Id { get; } = Tools.GetNextUniqueInteger;
    public required string TableNumber { get; init; }
    public required byte NumberOfSeats { get; set; }
    public bool Activ { get; set; } = true;
    public List<Reservation>? Reservations { get; set; }
    public required Restaurant Restaurant { get; set; }
}
