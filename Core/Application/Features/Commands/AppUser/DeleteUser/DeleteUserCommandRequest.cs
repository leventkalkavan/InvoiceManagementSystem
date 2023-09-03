using System.Text.Json.Serialization;
using MediatR;

namespace Application.Features.Commands.AppUser.DeleteUser;

public class DeleteUserCommandRequest: IRequest<DeleteUserCommandResponse>
{
    public string Id { get; set; }
}