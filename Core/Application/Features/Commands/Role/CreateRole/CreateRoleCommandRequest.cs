using MediatR;

namespace Application.Features.Commands.Role;

public class CreateRoleCommandRequest: IRequest<CreateRoleCommandResponse>
{
    public string Name { get; set; }
}