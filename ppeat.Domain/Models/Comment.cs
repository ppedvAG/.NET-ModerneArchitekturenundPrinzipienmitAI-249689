namespace ppeat.Domain.Models;

public class Comment : Entity
{
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public Guid RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public string CommentText { get; set; }
    public double Rating { get; set; }
}
