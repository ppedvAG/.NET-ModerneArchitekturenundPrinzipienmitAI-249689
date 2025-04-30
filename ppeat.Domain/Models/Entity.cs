using System.ComponentModel.DataAnnotations;

namespace ppeat.Domain.Models;

public class Entity
{
    [Key]
    public int Id { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset ChangedDate { get; set; }
}
