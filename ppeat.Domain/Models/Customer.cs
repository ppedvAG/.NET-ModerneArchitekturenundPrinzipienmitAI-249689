namespace ppeat.Domain.Models;

public class Customer : Entity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
    public ICollection<Comment> Comments { get; set; }
}
