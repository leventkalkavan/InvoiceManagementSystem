using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;

namespace Application.DTOs.UserDtos;

public class UserDto
{
    public string Id { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? CreditCardBalance { get; set; }

    public string Username { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string TC { get; set; }
    public string? CarPlate { get; set; }
    
}