using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace Application.Features.Commands.AppUser.CreateUser;

public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
{
    public string Username { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? CreditCardBalance { get; set; }
    public string TC { get; set; }
    public string? CarPlate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}