using System.ComponentModel.DataAnnotations;
using Domain.Entities.Authentication;
using Domain.Entities.Common;

namespace Domain.Entities;

public class House: BaseEntity
{
    public bool Status { get; set; }
    public string Type { get; set; }
    public string Block { get; set; }
    public int ApartmentNumber { get; set; }
    public int Floor { get; set; }

    public string AppUserId { get; set; }
    public ICollection<AppUser> AppUsers { get; set; }
    public ICollection<Invoice> Invoices { get; set; }
}