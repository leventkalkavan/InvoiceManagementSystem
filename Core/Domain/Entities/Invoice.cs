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
    
    public bool IsPaid { get; set; }
    public DateTime CreatedDate { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime LastPaymentDate { get; set; }
    public string HouseId { get; set; }
    public House House { get; set; }
}