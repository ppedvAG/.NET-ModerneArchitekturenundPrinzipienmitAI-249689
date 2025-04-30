namespace ppeat.Domain.Models;

public class Reservation : Entity
{
    public DateTime ReservationDate { get; set; }
    public int PersonCount { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
}
