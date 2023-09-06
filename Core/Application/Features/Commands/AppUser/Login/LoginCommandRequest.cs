using MediatR;

namespace Application.Features.Commands.AppRole.Login;

public class LoginCommandRequest: IRequest<LoginCommandResponse>
{
    public string NameOrEmail { get; set; }
    public string Password { get; set; }
}