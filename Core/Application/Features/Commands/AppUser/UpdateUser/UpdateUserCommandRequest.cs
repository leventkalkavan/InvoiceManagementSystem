using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MediatR;

namespace Application.Features.Commands.AppUser.UpdateUser;

public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
{
    
    public string Id { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? CreditCardBalance { get; set; }
    public string? CarPlate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}