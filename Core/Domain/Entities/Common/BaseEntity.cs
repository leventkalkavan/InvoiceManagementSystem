using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Common;

public class BaseEntity
{
    [Key]
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}