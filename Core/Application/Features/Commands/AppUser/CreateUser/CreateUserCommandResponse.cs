using MediatR;

namespace Application.Features.Commands.AppUser.CreateUser;

public class CreateUserCommandResponse 
{
    public bool IsSuccess { get; set; }
}