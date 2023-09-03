using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Authentication;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain.Entities;

public class Invoice: BaseEntity
{
    public string Name { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Bill { get; set; }
    public bool Status { get; set; }
    public DateTime LastDate { get; set; }

    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}