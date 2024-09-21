using System.ComponentModel.DataAnnotations;

namespace users.Models;

public class DefaultEntity : IEntity<Guid>
{
    [Key]
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }

    public bool IsDeleted { get; set; }
    public DateTime DeletedAt { get; set; }

}
