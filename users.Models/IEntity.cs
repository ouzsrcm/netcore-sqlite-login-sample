using System.ComponentModel.DataAnnotations;

namespace users.Models
{
    public interface IEntity<TKey>
    {
        [Key]
        TKey Id { get; set; }
    }
}
