using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Authentication;

public class AppUser: IdentityUser
{
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? CreditCardBalance { get; set; }
    public string TC { get; set; }
    public string? CarPlate { get; set; }
    public ICollection<House> Houses { get; set; }
}