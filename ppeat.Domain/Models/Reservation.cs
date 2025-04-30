namespace ppeat.Domain.Models;

public class Reservation : Entity
{
    public DateTime ReservationDate { get; set; }
    public int PersonCount { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public Guid RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
}
