using System.Text.Json.Serialization;
using MediatR;

namespace Application.Features.Commands.House.UpdateHouse;

public class UpdateHouseCommandRequest: IRequest<UpdateHouseCommandResponse>
{
    public string Id { get; set; }
    public bool Status { get; set; }
    public string AppUserId { get; set; }
}