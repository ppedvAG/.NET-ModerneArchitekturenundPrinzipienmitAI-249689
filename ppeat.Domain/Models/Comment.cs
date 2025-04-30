namespace ppeat.Domain.Models;

public class Comment : Entity
{
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public string CommentText { get; set; }
    public double Rating { get; set; }
}
