using ppeat.Domain.Enums;

namespace ppeat.Domain.Models;

public class Restaurant : Entity
{
    public string Name { get; set; }
    public string Location { get; set; }
    public int AvailableTableCount { get; set; }
    public double Rating { get; set; }
    public Cuisine Cuisine { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
    public ICollection<Comment> Comments { get; set; }
}
