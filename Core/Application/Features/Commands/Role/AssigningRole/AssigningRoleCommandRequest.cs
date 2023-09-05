using Application.DTOs.RoleDto;
using MediatR;

namespace Application.Features.Commands.Role.AssigningRole;

public class AssigningRoleCommandRequest : IRequest<AssigningRoleCommandResponse>
{
    public string UserId { get; set; }
    public string RoleId { get; set; }
}